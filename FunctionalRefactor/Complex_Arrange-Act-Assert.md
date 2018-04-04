# Complex Arrange-Act-Assert

In this seni-complex example, we take a function that has logic and IO mixed through out. Notice how the calls to `GetEnvironmentVariable`s is mixed in with the logic to arrange our problem.

It's hard to see, but there is also a hidden bug with `subscriberKey` that isn't very evident until the problem is rearranged.

```cs
public static async Task Run(EventData eventHubMessage, TraceWriter log)
{
    try
    {
        string body = Encoding.UTF8.GetString(eventHubMessage.GetBytes());
        if (body == "")
        {
            throw new Exception("No body in the Event.");
        }

        AssetEvent evnt = JsonConvert.DeserializeObject<AssetEvent>(body);
        
        await LogEvent(evnt, log).ConfigureAwait(false);
        await SendEvent(evnt, log, eventHubMessage).ConfigureAwait(false);
    }
    catch(Exception ex)
    {
        await LogException(ex, log).ConfigureAwait(false);
        log.Info(ex.Message);
        throw;
    }
}

public static async Task SendEvent(AssetEvent evnt,TraceWriter log, EventData eventHubMessage)
{
    var _requestUri = GetEnvironmentVariable("RequestUri");

    object appToken;
    if (false == eventHubMessage.Properties.TryGetValue("AppToken", out appToken))
    {
        throw new Exception("No app token in the Event.");
    }

    string appTokenString = (string)appToken;
    string subscriberKey = GetEnvironmentVariable($"AppToken:{appTokenString}:{evnt.AccountId}");

    var client = GetHttpClient(subscriberKey);
    var json = JsonConvert.SerializeObject(evnt);
    var stringContent = new StringContent(json,
                    Encoding.UTF8,
                    "application/json");

    var response = await client.PostAsync(_gpsServiceRequestUri, stringContent).ConfigureAwait(false);

    if(!response.IsSuccessStatusCode)
    {
        await LogError($"Error ocurred while calling endpoint: {response.ToString()}",evnt,log).ConfigureAwait(false);
    }
}

private static HttpClient _client;

public static HttpClient GetHttpClient(string subscriberKey)
{
    try
    {
        if (_client != null) return _client;
        var _serviceEndpoint = GetEnvironmentVariable("serviceEndpoint");
        var _subscriberKeyHeaderName = GetEnvironmentVariable("SubscriberKeyHeaderName");
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
        _client.DefaultRequestHeaders.Add("Keep-Alive", "timeout=600");
        _client.BaseAddress = new Uri(_serviceEndpoint);
        _client.DefaultRequestHeaders.Add(_subscriberKeyHeaderName, subscriberKey);
        return _client;
    }
    catch (Exception)
    {
        throw;
    }
}
```

In the refactored solution, there is a single large body, but all the up-front work is done to 'arragnge' the varaibles/objects, and then we use the arranged items to execute the IO call.

```cs
public static async Task Run(EventData eventHubMessage, TraceWriter log)
{
    string correlationId = null;

    try
    {
        string body = Encoding.UTF8.GetString(eventHubMessage.GetBytes());
        if(body == "")
        {
            throw new Exception("No body in the Event.");
        }

        AssetEvent evnt = JsonConvert.DeserializeObject<AssetEvent>(body);
        
        object corrId = null;
        eventHubMessage.Properties.TryGetValue("CorrelationId", out corrId);
        correlationId = (string) corrId;

        await LogEvent(evnt, correlationId, log).ConfigureAwait(false);

        object appToken;
        if (!eventHubMessage.Properties.TryGetValue("AppToken", out appToken)) {
            throw new Exception("No app token in the Event.");
        }

        string subscriberKey = GetEnvironmentVariable($"AppToken:{(string)appToken}:{evnt.AccountId}");
        var _subscriberKeyHeaderName = GetEnvironmentVariable("SubscriberKeyHeaderName");
        var _requestUri = GetEnvironmentVariable("RequestUri");
        var _serviceEndpoint = GetEnvironmentVariable("Endpoint");

        var client = GetHttpClient(_serviceEndpoint);
        var json = JsonConvert.SerializeObject(evnt);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        content.Headers.Add(_subscriberKeyHeaderName, subscriberKey);
        content.Headers.Add("CorrelationId", correlationId);

        var response = await client.PostAsync(_requestUri, content).ConfigureAwait(false);
        
        if(!response.IsSuccessStatusCode)
        {
            await LogError($"Error ocurred while calling endpoint: {response.ToString()}", evnt, correlationId, log).ConfigureAwait(false);
        }

        log.Info("Function Completed");
    }
    catch(Exception ex)
    {   
        await LogException(ex, correlationId, log).ConfigureAwait(false);
        log.Info("Run Failed. Exception: " + ex.Message);
        throw;
    }
}

public static HttpClient _HttpClient;

public static HttpClient GetHttpClient(string serviceEndpoint) {
    if (_HttpClient == null) {
        _HttpClient = new HttpClient();
        _HttpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
        _HttpClient.BaseAddress = new Uri(serviceEndpoint);
        _HttpClient.Timeout.Add(new TimeSpan(0,10,0));
    }
    return _HttpClient;     
}
```

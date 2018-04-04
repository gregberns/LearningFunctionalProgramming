

```cs

public static async Task Run(EventData myEventHubMessage, TraceWriter log)
{
    try
    {
        string body = Encoding.UTF8.GetString(myEventHubMessage.GetBytes());
        if(body == "")
        {
            throw new Exception("No body in the Event.");
        }

        log.Info($"C# Event Hub trigger function processed a message: {body}");

        SpireonSubscriberAssetEvent evnt = JsonConvert.DeserializeObject<SpireonSubscriberAssetEvent>(body);
        // There is an issue with Newtonsoft that it cannot grab the value from lat & lng and set it equal to Latitude and Longitude so this will temporarily do the job

        await LogEvent(evnt, log).ConfigureAwait(false);
        await SendEvent(evnt, log, myEventHubMessage).ConfigureAwait(false);
    }
    catch(Exception ex)
    {
        
        await LogException(ex, log).ConfigureAwait(false);
        log.Info(ex.Message);
        throw;
    }
}

public static async Task SendEvent(SpireonSubscriberAssetEvent evnt,TraceWriter log,EventData eventHubMessage  )
{
    // Grab global app settings

    var _gpsServiceRequestUri = GetEnvironmentVariable("GpsServiceRequestUri");

    // Pull token out and create the subscriber key
    object appToken;

    if (false == eventHubMessage.Properties.TryGetValue("Nspire-AppToken", out appToken))
    {
        throw new Exception("No app token in the Event.");
    }

    string appTokenString = (string)appToken;
    string subscriberKey = GetEnvironmentVariable($"Spireon:AppToken:SubscriberKey:{appTokenString}:{evnt.AccountId}");

    var client = HttpCaller.GetGpsHttpClient(subscriberKey);
    var json = JsonConvert.SerializeObject(evnt);
    var stringContent = new StringContent(json,
                    Encoding.UTF8,
                    "application/json");
    log.Info("Making call to GPS");
    var response = await client.PostAsync(_gpsServiceRequestUri, stringContent).ConfigureAwait(false);
    log.Info("Response " + response.IsSuccessStatusCode);

    if(!response.IsSuccessStatusCode)
    {
        await LogError($"Error ocurred while calling Shared GPS: {response.ToString()}",evnt,log).ConfigureAwait(false);
    }
}
```


```cs

public static async Task Run(EventData myEventHubMessage, TraceWriter log)
{
    string correlationId = null;

    try
    {
        string body = Encoding.UTF8.GetString(myEventHubMessage.GetBytes());
        if(body == "")
        {
            throw new Exception("No body in the Event.");
        }

        SpireonSubscriberAssetEvent evnt = JsonConvert.DeserializeObject<SpireonSubscriberAssetEvent>(body);
        // There is an issue with Newtonsoft that it cannot grab the value from lat & lng and set it equal to Latitude and Longitude so this will temporarily do the job
        
        object corrId = null;
        myEventHubMessage.Properties.TryGetValue("CorrelationId", out corrId);
        correlationId = (string) corrId;

        //Remove logging durring testing to see if the HTTP is causing issues
        await LogEvent(evnt, correlationId, log).ConfigureAwait(false);

        object appToken;
        if (!myEventHubMessage.Properties.TryGetValue("Nspire-AppToken", out appToken)) {
            throw new Exception("No app token in the Event.");
        }

        string subscriberKey = GetEnvironmentVariable($"Spireon:AppToken:SubscriberKey:{(string)appToken}:{evnt.AccountId}");
        var _subscriberKeyHeaderName = GetEnvironmentVariable("SubscriberKeyHeaderName");
        var _gpsServiceRequestUri = GetEnvironmentVariable("GpsServiceRequestUri");
        var _gpsServiceEndpoint = GetEnvironmentVariable("GpsServiceEndpoint");

        var client = GetTelematicsHttpClient(_gpsServiceEndpoint);
        var json = JsonConvert.SerializeObject(evnt);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        content.Headers.Add(_subscriberKeyHeaderName, subscriberKey);
        content.Headers.Add("CorrelationId", correlationId);

        var response = await client.PostAsync(_gpsServiceRequestUri, content).ConfigureAwait(false);
        
        if(!response.IsSuccessStatusCode)
        {
            await LogError($"Error ocurred while calling Shared GPS: {response.ToString()}", evnt, correlationId, log).ConfigureAwait(false);
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

public static HttpClient _telematicsHttpClient;

public static HttpClient GetTelematicsHttpClient(string gpsServiceEndpoint) {
    if (_telematicsHttpClient == null) {
        _telematicsHttpClient = new HttpClient();
        _telematicsHttpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
        _telematicsHttpClient.BaseAddress = new Uri(gpsServiceEndpoint);
        _telematicsHttpClient.Timeout.Add(new TimeSpan(0,10,0));
    }

    return _telematicsHttpClient;     
}

```

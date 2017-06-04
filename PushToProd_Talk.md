# Push to Prod

the following is designed to make you p****d off… (if you’re ~90% of C-like(C#/Java) devs living the imperitive lifestyle)

// remember: nothing in this talk is original

// nothing in this talk is new

// everything in CS is 30+ years old (probably before you were born)

// you are not dumb, but these  may be new ideas. if you’re smart they should make you question everything

// seriously, question everything...

![question everything)](http://amorebeautifulquestion.com/wp-content/uploads/2012/12/EintsteinQuestionEverything1.png)

//30 yrs ago


> It compiled successfully … so push to prod 
> 	- old school dev joke ( ask Steve and Mark, they may get it )

// my last job(my first job), 'senior' devs talked (joked) about how they did/said this back in the day.

![It compiled...Push to prod](https://jeremiahsaysa7da.blob.core.windows.net/jeremiah-says-memes/jeremiahsays05680228-0204-4a98-bddc-2e8c91664dc3.png)

// today…

// "did QA find anything in regression?" "Nope." (even though there’s 100k lines of code to test…)

// "How long did it take to test?" "only a day… its fine, push it"

// (push to prod)

// "oops, forgot to take care of that edge case"


// Whats wrong with this

```
fn(i){
  var v = getValue(i)
  var n = v.Name
  return n
}
```

// A colleague told me “You should always be checking for nulls”

// so…

```
fn(i){
  var v = getValue(i)
  var name;
  if (v == null){
    // what the f**k do I do here
    // lets throw an exception. Then it’ll be someone else problem!
  } else {
    name = v.Name
  }
  return name
}
```

Someone elses problem...

```
var n = fn(i)
```

Prod goes down.... oops

Dev corrects...

```
try {
  var n = fn(i)
catch(e){
  //what the m*ther f*****g s**t do I do here
  //why didn’t that sh*tty other dev tell me there’d be an exception thrown
  //maybe I should create a custom exception to throw here…
  //and create more code that needs to be maintained and that can fail
  //so some other sh*tty dev can be blamed
  throw new SomeoneElsesProblem(e)
}
```

// An alternative... (that you'll most likely hate and throw things at me for)

//And yes, I’ve argued with other dev about this, you’re not the first

//Oh and this isn’t my idea, much smarter people cam up with this in 40 years ago

// Idea: why not return either the thing or nothing?

```
fn(i){
  Maybe<Name> e = getValue(i)
  match (e) {
    Nothing:  return Nothing
    Something: return e.Name
  }
}
```

```
fn :: int -> Maybe Name
fn(1)
  .IfSomething(name => console.log(name))
  .IfNothing(() => console.log(‘Nothing found’))
```

Again... 

question everything… maybe what you’ve been doing is wrong, or you’re using a sh*tty language (read: not very powerful)

![question everything](https://sd.keepcalm-o-matic.co.uk/i/keep-calm-and-question-everything-2.png)


## Time to Leave

This is the time to leave if your brain is at capacity and unwilling or unable to take anything new on. 

I get it. It took me 2 years to wrap my head around this. Say 'uncle' if you must.


[Reference for the following](https://www.schoolofhaskell.com/school/starting-with-haskell/introduction-to-haskell/1-haskell-basics)

## functional

// functions are first-class, that is, functions are values which can be used in exactly the same ways as any other sort of value.

// evaluate expressions rather than executing instructions



## pure

// 1) No mutation! Everything (variables, data structures...) is immutable.

// 2) Expressions never have “side effects” (like updating global variables or printing to the screen).

// 3) Calling the same function with the same arguments results in the same output every time.



## types

// forces you to do some heavy lifting at the start (read: actually understand the problem you’re trying to solve before writing code… oh goodness!!)

// who here normally says…”well let me write some code to figure out how we might accomplish this?” (everyone should be raising their hand)



// Static type systems can seem annoying. In fact, in languages like .NET and Java, they are annoying. But this isn’t because static type systems per se are annoying; it’s because .NET and Java’s type systems are insufficiently expressive! 

Helps clarify thinking and express program structure

// give an example here of ‘Delete Gps’

// lets be responsible devs and figure out what were going to do before we spend n days slaving a way, just to find out our idea was s****y. I mean, won't work.



## lets use types to solve a problem

DDD (domain driven development) says figure out what your ‘domain' looks like so your code can reflect your domain

(note: I’m a big fan of ddd)

only problem is DDD doesn’t provide a rigorous way to define the domain, it only provides cloud blobs pointing to other cloud blobs

'denotational design' provides a rigorous way to define our domain or solution space



## this will be new syntax, prepare yourself.

// :: is pronounced “has type”

functionName :: param1 -> param2 -> returnValue




// notice all ‘entities’ are actually typed, not just strings/ints. (read: primitive obsession)

```
fetchSoldVehicles :: Date start -> Date end -> IO [(StockNumber, Location)]  // DocumentManagement Db
findVehicle :: (StockNumber, Location) -> IO (Vin, GpsProduct, Reason) // Retail Svc
fetchProduct :: (Vin, GpsProduct, Reason) -> IO (DeviceKey, SaleDate) //Telematics Svc
computeSaleDate :: (DeviceKey, SaleDate) -> Date now -> (DeviceKey, ExpireDate)
computeProcessType :: (DeviceKey, ExpireDate) -> HowToProcess
type HowToProcess = 
  | DeleteDevice DeviceKey ExpireDate
  | DeleteInTheFuture DeviceKey ExpireDate
  | Unhandled DeviceKey
processVehicles :: (DeviceKey, Reason) -> Unit  // (read: Unit == void) // Telematics Svc
```


## implementation

```
fetchSoldVehicles(start, end)
  .map(findVehicles)
  .map(fetchProducts)
  .map(processVehicles)
  .map(computeSaleDate)
```


## consider performance

* what functions take the longest to perform?
* 

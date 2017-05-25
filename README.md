# Learning Functional Programming

A collegue asked me about functional programming and said "I haven't had a chance to do much of it. What language are you using?". It got me thinking. 

The following is a super simple getting started guide to Functional Programming (FP).

Don't be scared, it won't hurt... too bad. You might need to re-think some of the paradigms you've beed using in the past.

First things first...

## What you DO NOT need to do to learn Functional Programming (FP)

* YOU DO NOT NEED TO learn a new language - If you know Javascript or C# you're good to go. No need to try and take on a new language.
* YOU DO NOT NEED TO learn scary terms like 'monad', 'functor' or 'semigroup'. These are mathematical terms. IGNORE THEM. (For now. At some point there are some simple ideas that you can use to remember what each is.)
* YOU DO NOT NEED TO learn Haskell. In fact, if you are a C#/JS dev, do not go and try and learn it first. Its a steep learning curve and there are better ways of getting started.

## What you CAN do to get started down the FP road

* Most functions should be 'Pure' functions - If you do nothing else, do this. I guarentee you will be a happier developer for it.  (Pure functions will be discussed further below.)
* NO MORE FOR LOOPS - For loops are evil. They start with one line and grow like a virus. Use Linq's `Select` instead.
* Use Linq to process all lists of objects. `Select`, `Where` and `Aggregate` are the ones to start with.
* Separate IO (HTTP/Disk/DB calls) from business logic and data transformations - Think IO, PureFx, IO, PureFx, IO, PureFx. 
* Move State out of 'complex' objects - Move State out of your classes into objects that can be passed through a pipeline and transformed.
* Classes ONLY do one of a couple things: 1) do IO, 2) are data objects (think 'DTOs'), or 3) have a collection of pure functions

## Notes

### On C#

C# and Linq is a great place to start with FP. The challenge is that functions can be passed around as `Func<object, object>` but larger signatures can become difficult to read. Once you've used Linq to get rid of ForEach loops, you can look at libraries like (LanguageExt)[https://github.com/louthy/language-ext] to take the next FP step.

### On Javascript

JS is a great functional language. The challenge you'll find is because its dynamic, ensuring types match up can be a bit challenging. To get started, use `map`, `filter` and `reduce` functions on arrays to process them. When you're ready for the next step, look at (Rambda)[http://ramdajs.com/] or (lodash/fp)[https://github.com/lodash/lodash/wiki/FP-Guide]. (Note: lodash is great but there are some things lodash/fp does that will make more sense later)

## Pure Functions

Pure functions are the most important thing to understand when 

Think of a pure function as one that you could call a million times, and it will always return the same thing, AND there will be no 'effects' like writing to the database, console, HTTP, etc.

Impure:

```
var i = 0;
void increment() {
  i++;
}
```

Pure:

```
int increment(i) {
  return i + 1;
}
```

Pure functions allow us to 'reason' about what the code is going to do very easily. 

Impure code makes it a challenge to understand what 'effects' will occur in the environment when a method is called.

To test an impure function you also need to make sure that the environment is in a particular 'state' before you execure the test. With Pure functions, everytime you call the function with the same parameters it will ALWAYS return the same value.

The benefits of pure functions abound. Parallelizing code, reasoning, testing, composing (combining multiple pure functions), and many more benefits come out of using a majority of pure functions.

### Further Reading

* Lambda Calculus - Don't worry, you don't have to remember calculus to understand lambda calculus. Think of lamda calculus as only being able to use JS lambda ('arrow') functions to create everything, like `if`, `equals`, `true`, and recursion. Check out (this)[https://github.com/gregberns/FunctionalExamples/blob/master/JSLambdasAllTheWayDown.js] and (this)[https://github.com/gregberns/FunctionalExamples/blob/master/LambdaCalculusIntro.md] for more info.

## No More For Loops

For loops are evil. 

They start out with great intentions:

```
foreach (var i in list) {
  Console.WriteLine(i);
}
```

But then the turn into:

```
// { 1 .. 100 } :: meaning a list of 100 items
List list = new List<String>() { 1 .. 100 }
foreach (var i in list) {
  Console.WriteLine(i);
}
void method1(String i) {
  // oops... now we have a serious performance issue...
  database.Insert(i)
}
```

Or they start to grow legs and turn into unmaintainable monsters...

```
foreach (var i in list) {
  var o = new Object();
  // 1000 lines later....
  Console.WriteLine(o);
}
```

The alternative. Take FizzBuzz. Simple problem, right...???

```
for (var i = 1; i > 100; i++) {
  if (i % 3 == 0 && i % 5 == 0) {
    Console.WriteLine("FizzBuzz");
   }
   //Ect...
}
```

But how is that testable??? Other than debugging or visually looking at the console, how to you make sure that you got the 'i > 100' correct (cause I can never remember). How do you make sure you got the `(i == 15) = "FizzBuzz"` case correct?

What if you pulled out the 'core' logic, so you could validate each case (there are 4) are correct?

```
Enumerable.Range(1, 100)
  .Select(i => FizzBuzz(i))
  .ToList()
  .ForEach(s => Console.WriteLine(s));

string FizzBuzz(i) {
  if (i % 3 == 0 && i % 5 == 0) {
    return "FizzBuzz";
   }
   //Ect...
}
```

See how the data processing logic is separated from the usage of the logic?

The use of `Select`, `Where`, and `Aggregate` in C# and corresponding `map', `filter`, and `reduce` functions in JS, can help you pull out the complex logic done to list items, so the logic can be done in small, testable functions.

## Separate IO from Logic

IO is slooooooow. And generally not easily testable. So lets get it out of the easily testable, fast code.

Lets make IO EXPLICIT. so when we do it, we know we are doing it, and it is obvious.

In OOP, they talk about 'DRY' and 'Single Responsibility', but implementing methods that are actually truly reusable often can become difficult. When you implement a method that does this:

```
method (object o) {
  //do some business logic on o
  var newO = database.write(o)
  //do some more business logic on newO
}
```

How do you reuse the logic when you need to insert multiple records?

In FP land, we would do something like this:

```
batchMethod (list) {
  var newList = list.Select(i => PreTransform(i))

  var result = database.writeBatch(newList)

  var newerList = result.Select(i => PostTransform(i))
  return newerList
}

function PreTransform(i) { //logic }
function PostTransform(i) { //logic }
```

We make sure to keep the transformation logic separate from the IO (database call), so that it is actually reusable.

In the single object use case, you can just use the `PreTransform` and `PostTransform` functions, and in the list processing you can do the same thing.


## Move State out of 'complex' objects

// Section needs better examples

All the good OOP books say methods should be small and reusable. They also say they should 'encapsulate state'. The problem is that when you need to do transformations of an object's state the order of operations often becomes critical.

```
// Some example here where you have to do 
class Person {
  DoSomething() { //logic }
  DoSomethingElse() { //logic }
}
```

The user of the object will have to know what `DoSomething` and `DoSomethingElse` does, to understand or 'reason' about what will occur.

Instead we could make the `Person` object 'immutable' (where its values/properties cannot change), then do calculations / perform logic on it.

```
//Improve this example
var person = new Person
var newData = DoSomething(DoSomethingElse(person))
```

During the transformation, `Person` never changed, it was just used to do logic on.


## Make all methods 'public' methods

// needs improvement

Again, OOP is all about encapsulating the data and attaching methods to change and modify that data. Because of this, OOP-ers often need to hide these capabilities from the consumer of the object, so they can't corrupt the data.

If all your public functions are pure functions, you aren't going to corrupt any internal 'state' data. You will just get back a new transformed object that you can do with it what you please.

In FP land we say "we'll give you data and some functions to operate on that data, if you screw it up thats your peoplem, we still have the original data".

Lets say there was a 'module' that had several pure functions attached to it, and there was a separate 'Person' object that contained only data. To 'change' the person object you had to pass it into the pure function, and you would get a new transformed object back. Exposing those capabilities allows the user to change 'Person' into a new object, but the old object woud remain.

Some would argue that you are 'exposing the inner workings of the class', but FP would say, no were just exposing 'capabilities' or functions you can perform on an object.


## Stop using null

In 1965, Sir Tony Hoare introduced null reference. Since then he apologised for that and called it [The Billion Dollar Mistake](https://www.infoq.com/presentations/Null-References-The-Billion-Dollar-Mistake-Tony-Hoare). If the inventor of null pointers and references has condemned them, why the rest of us should be using them?

Many programmers have been using them so long they don't realize there ARE other options.

The other options are `Option`'s (also known as `Maybe` types in certain languages). Option is a type in most FP langs. You can either have a `Some<T>` or a `None`. So instead of returning null, None can be returned. This may appear to be a subtle difference, but it results in significantly improved code.


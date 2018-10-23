




## Classes of Errors

Type systems get rid of certain classes of errors.
Dynamic languages fail at runtime when a property doesn't exist. This is one class of errors.
C# utilizes the `null` construct extensively which causes most runtime errors (in my expreience). 
Haskell and other statically typed functional languages use their type systems to get rid of many classes of errors conventional languages encounter.

Haskellers, only semi-jokingly say: "if it compiles, it will work".
Often this isn't far from the truth.
In Javascript, if you spend 30 minutes writing code, it is very unlikely you'll be able to get 20% through without an error.
In C#, I'd say you might be able to get half way thorugh, then fail with an 'Object reference' error.
Many times in Haskell, once it compiles you get very excited because 90% of the time it will run to completion.

Caviat: This does not mean that a failure of business rules wont occur or there wont be bugs, just that the program will run to completion.

Missing
* Haskell does not have casting of types

Contains
* Algebraic data types



### Datatype-generic programming

C# contains 'Generics', which wasimplemented in .NET in 2.0. The implementers were the functional programmers: Don Syme (F# designer), Erik Meijer (LINQ creator). In fact, LINQ is dependent on generics to work and is very much is the functional programming part of C#.

Generics are important when working with Higher Order Functions. "A higher order function is a function that takes a function as an argument, or returns a function." Functions like: `map`/`Select`, `filter`/`Where`, `fold`/`reduce`/`Aggregate`, etc.



## Expressions

> The first step in truly understanding Haskell’s type system is to remember the fundamental difference between functional programming and imperative programming. In imperative programming, we are giving the program a series of commands to run. In functional programming, our code actually consists of expressions to be evaluated. Under Haskell’s type system, every expression has a type.

[Understanding Haskell's Type System](https://mmhaskell.com/blog/2016/12/5/7mkljzq7zy97d66zm4yvtn8v1ph502)

When you are working only with expressions, new, very different properties become available.




```
function (a, b, c) {
  return a > b ? a
       : b > c ? b
       : c;
}
//vs
function (a, b) {
  if (a > b) {
    return a
  } else if (b > c) {
    return 
  }
  return c
}
```



## Types vs Testing

The Ruby community brough unit testing into the mainstream by making it common practice within their projects. Ruby is dynamically typed and so to maintain high quality they used testing to help ensure quality and eliminate issues found in dynamic languages.

Without types it is easy to make the following mistake:

```
function add(a, b){
  return a + b
}
add(1, "a")
```

If we add types, `add` can be tested, but we don't need to check that `a` and `b` are both integers. In a dynamic language it is much more important to ensure what is being passed to a function is correct.

There are disagreements within communities whether we can get rid of tests if we use rigorus types.

The practical minds seem to have settled on both, used appropriately. Types solve certain problems, but we need tests to catch issues our types cannot reveal.

## Implicit Typing

Downsides of static typing can be that there is more code to write, namely the types! This is especially true in languages in Java and C#. Haskell and F# are slightly different.
In some cases you need to explicitly add types, but this is not common. It is good practice to have all public Api's have hard coded types. But because of the type inference is so powerful, types can often be left off in many places. It is generally good practice to have types on most functions, but some functions can be built with quite complex sets of expressions, which do not need to be typed.


The compiler is quite good, and generally does not need explicitly defined types.
But it is good practice to give a signature for your top level functions.
In some cases you need to explicitly add types, but this is not common.

It is good practice to provide top level types and one of the reasons we do this is because it allows us to reason about what the function does, without looking at the implementation. This may not make sense for most new comers, but after a bit of training and practice, its pretty incredible. The type signatures are like an X-Ray into the function, they let you see certain critical properties of the function, without digging in and opening it up.


## Reasoning With Types

Haskell has a distinctive type annotation that once familiar with is quite easy to read and helps us 'reason about' or predict what a function will do.

The syntax is something like this:

```
InputParameter -> InputParameter -> OutputValue
```

Or with actual types:

```
Integer -> Integer -> Integer
```

What could that type signature represent?

```
function (a: Integer, b: Integer) { return a + b }
// or
function (a: Integer, b: Integer) { return a - b }
```

Or something more interesting:

```
// [a] -> [a]
function ([string] listA) { return listA.reverse() }
//or
// (a -> b) -> [a] -> [b]
function map(Func<a, b> f, List<A> listA) {
  var newList = []
  for (i in listA) {
    newList.add( f(i) )
  }
  return newList;
}
```

If provided just a type signature, it is often possible to guess what the function is going to do. Inversly, if we need a function that does a particular thing, we can look for type signatures that match what we want, then sort through the small subset to find the one we want.

Try to guess what functions these type signatures could represent:

```
// Why would we want to prevent a number from being zero? What computation could fail if the second parameter was zero?
Number -> NonZero -> Number

//This takes a function from `a` to `Boolean` and a list of `a`, and returns a new list of `a`
// (Hint: the length of the return list could be less than the input list)
(a -> Boolean) -> [a] -> [a]
```




## Deficiencies
* Incapable of preventing infinite loops (some languages can prevent this)




## Terms

* [implicitly typed](http://wiki.c2.com/?ImplicitTyping) - Implicit Typing is a term for any language typing system which requires few or no type annotations (type declarations of variables, object members, function arguments, etc.)

[Higher Order Functions](https://medium.com/javascript-scene/higher-order-functions-composing-software-5365cf2cbe99) - "A higher order function is a function that takes a function as an argument, or returns a function."

## References

* [What exactly makes the Haskell type system so revered (vs say, Java)?](https://softwareengineering.stackexchange.com/questions/279316/what-exactly-makes-the-haskell-type-system-so-revered-vs-say-java)
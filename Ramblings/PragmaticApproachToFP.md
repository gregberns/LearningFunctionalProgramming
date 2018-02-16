# A Pragmatic Approach to Functional Programming

This repository is a series of talks on a Pragmatic Approach to Functional Programming in C#

It may also be applicable to TypeScript developers, and any other devs that are open to new ideas.

I also hope more senior devs can take some of the ideas introduced and apply them quickly to their active projects. Once these ideas are absorbed, even the most seasoned devs might see the light and realize there's a better way.

## Talk Objective:
Instead of ‘teaching’ some ideas that you might be able to apply one day, lets focus on techniques you can use today. 

**To learn something, you need to use it. To use an idea, you need a practical way to apply it in as many places as possible and as quickly as possible.**

The objectives of these talks is to start with a core set of simple examples and build on them. The talk will start with a standard set of knowledge that most C# developers generally have and (hopefully) expand on that domain of knowledge.
(If you are unfamiliar with any concepts, there are many resources out there to learn from).

My hope is to give any developer with a decent understanding of either C# or Typescript, a path forward in learning better practices and patterns to learn from.

We have all written code that we are not proud of (and have spent a significant time refactoring).

Hopefully, these talks will help:

- Prevent common bugs from occuring
- Make validation easier and more robust
- Handle all use cases, instead of the ones you can think of right now

Take these talks as a starting point to understand where the flaws in your system are. Once flaws are identified, the solution may not be easy, but the use of diligent thought and strong typing will reveal a robust and consistent way to handle edge cases, which fully utilize the tools available (your compiler).

**Warning: Strong language used in this talk. Don't take anything said here personally. I’ve written garbage (read: error prone) code like this for many years. This is a small attempt to atone for my refactorings of the past.**

## Talks

* [Intro - Why FP is Powerful](WhyFpIsPowerful.md)
* [Stop Object Reference Errors in their Tracks](StopNullReferencesInTheirTracks.md)
* [Stop Using For Loops](StopUsingForLoops.md)
* Programming with Expressions - ToDo
* Catch Errors Early and Often - ToDo
* Make Impossible States Impossible - [Talk by Richard Feldman on Elm](https://www.youtube.com/watch?v=IcgmSRJHu_8)


## New Types (Ideas)

There are a variety of new types introduced here that may be unfamiliar.

As with anything unfamiliar, keep your mind open. 

Any developer worth their salt will be able, with effort, to understand all these concepts and their application.

The examples used in this talk use the [LanguageExt](https://github.com/louthy/language-ext) repository on Github. It is an extraordinarily well developed 'base class' library for C#, and used in production in quite a few places.

There are several other libraries that accomplish similar goals in both C# and TypeScript.

### C#

* [LanguageExt](https://github.com/louthy/language-ext) - An extensive base class library that provides a truely functional programing experience to C# developers
* [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions) - a simple set of types to provide types like `Option` and `Either` to C# developers. A great starting point.

### Javascript

* [RambdaJs](http://ramdajs.com/) - provides higher order functions (like map, filter, reduce and more) to operate on common JS data structures
* [Monet](https://monet.github.io/monet.js/) - provide other 'structures' to help lift your types to new heights


## Functional Programming Jargon

When experiences programmers (C#, Java, Ruby) developers are exposed to Functional Programming, there is often a very scary 'cliff' of jargon that some believe is required to overcome.

When understanding something new, it is not always required to understand the deeper ideas at first. You can often use a simplistic understanding to 'get things done' and evolve that into a more comprehensive understanding.

Example:
In OOP, you do not need to understand polymorphism and Liscovs Principle (the 'L' in SOLID) to start understanding OOP and its principles.

https://github.com/hemanth/functional-programming-jargon



## FP is fundamentally different

https://www.quora.com/What-are-some-myths-about-functional-programming-and-functional-programming-languages

Going from Java to C# is just trivial. Going from Java to Python requires a slight shift in mentality, but it's basically the same thing. Even going from C to Java isn't that bad--in terms of concepts, Java adds on top of the same foundation as C. You have variables, control structures, statements and expressions. It's a gradual progression from the very first language you learned to the new imperative language du jour.

Functional programming is nothing like that. It really pulls the rug out from underneath your feet. The most fundamental ideas are completely replaced. No more statements. No more loops. No more variables. Hell, no more execution--instead of running a functional program, you evaluate it.


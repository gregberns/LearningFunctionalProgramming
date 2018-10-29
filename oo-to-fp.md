# Learning Functional Programing as an Object Oriented Developer

The following is a set of excercises and lessions to learn functional programming concepts when coming from an Object Oriented (read imperitive) style of programming.

## Excercises

* Improving FizzBuzz
* Functional Programming for Non-programmers
* Refactoring problems
* Function Composition
* Expression Oriented Programming

### Improving on Fizz Buzz

FizzBuzz is a common interview programming problem. Almost everyone writes it exactly the same way, which violate almost all of the SOLID and DRY principles and is untestable.

There are some significant improvements to be made which make the code testable, extendable and 

The purpose of this excercise is to show even the most experienced programmers that there are significant improvements and changes that can and should be made to their code.

### Functional Programming for Non-programmers

[Functional Programming for Non-programmers](https://github.com/gregberns/LearningFunctionalProgramming/blob/master/fp-for-non-programmers.md) attempts to show the most important idea in functional programming: "referential transparency", but attempts to show it in a way that a non-programmer can grasp.

To understand Functional Programming, dont start with immutability or lambda calculus or no shared state or no side effects. 

Those are just valuable attributes that fall out of having this "referential transparancy" thing.

### Refactoring Patterns

[Refactoring Patterns](https://github.com/gregberns/refactor-spectacular/tree/master#refactoring-patterns) will show a couple patterns to use when refactoring to a more expression based or functional style.

### Function Composition

Use a [string parsing example](./CodeExamples/string-parsing.js) to compare and contrast a 'standard' parsing example with one done with function composition.

The objective is to show off how creating simple, re-usable, general functions can be combined into powerful, specific functions.

### Expression Oriented Programming

[Expression Oriented programming](https://github.com/gregberns/LearningFunctionalProgramming/blob/master/Ramblings/YouDontKnowFunctionalProgramming.md#expression-oriented-programming) is a paradigm or style you can start using in your imperative code bases to move toward a more Expression based or Functional style.

The objective is once EOP is learned in C#/Java/JS, it makes it much easier to think in a functional way and start writing larger pieces of functional code.





### Future Ideas

* Higher Order Functions
  * Do an intro to LINQ - both syntaxes, lists and single items(Option/Maybe)
  * ETL of parsing/vaidation of a JSON message file. Can use LINQ
  * Can we build a structure on the fly to do this?
* Build the `maybe` data structure, show how its used, and how to access it’s internal data (encapsulation). Show how `map` is used to handle the data.
* Show how async/await is almost `do` notation

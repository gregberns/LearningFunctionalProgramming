Some functional things...

## Lamda calculus

Lambda calculus is the basis for functional programming paradigms

* LambdaCalculusIntro - is some intro material to learn about lambda calculus
* JSLambdasAllTheWay - shows how to do lambda calculus with Javascript

## Pure Functions

Pure functions are functions which:

* can be executed with the same parameters any number of times and always return the same result
* do not 'effect the outside world' and they are not 'effected by the outside world' (we'll cover 'effects' more in a bit)

For example, this function is pure, because it can be executed infinite times and will always return the same value.

```
function increment(count) {
  return count + 1
}
```

As opposed to this method which ends up referencing state, and so everytime it is called it will return a different result.

```
var count = 0;
function increaseCount(val) {
    count += val;
    return count;
}
```

As another example, this function is impure because it will return a different value every time the function is called.

```
function timeDiffernce(later) {
  return later - Date.now;
}
```

To make the function pure, we can remove the time reference and pass it in as a parameter like so.

```
function timeDiffernce(now, later) {
  return later - now;
}
```

Functions with 'effects' are those that when run have some impact on the world or are impacted because of some state of the world.

Some symptoms of 'effectful' functions

* console.log()
* touch a database
* 


To see an example of transforming a 'impure' set of functions to a set of pure functions, take a look at 'FizzBuzzFunctions'.

A pure function is one that has no effects. 


Effects are changes or input from to something outside the program, such as `console.log()`, 

This function is easily testable because the same parameters will always return the same values. 





## Isolating Effects


## Recursion

Recursion is used heavily in functional programming. Recursion is used in functional programming in the same way while and for loops are used in imperitive style programming. As a note, in lambda calculus there are no named functions and so a function cannot call upon itself. Because of this the Y Combinator was created. It allows an unnamed function to call itself.



Higher-Order functions
Functional Composition
Function Purity
Isolating Side effects

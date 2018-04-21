# Lambda Calculus

You can also start with the underpinnings of functional programming: lambda calculus.

```
\x.x
```

This is lambda expression. 
The \ is a lambda symbol
The first x is the first and only parameter of the lambda
The period separates the parameters from the body expression
The second x is the body expression and references the x parameter
This is equivalent to (x) => x in Javascript

(\x.x)y -> This means pass y in as the first parameter of \x.x

This is a decent paper to start out with. Its a little dense but not too hard to read. 
You just need to read the first couple pages (to page 5) (after that it gets a little wild.)

http://www.inf.fu-berlin.de/lehre/WS03/alpi/lambda.pdf


Once you are asking yourself why any of that is important, then watch
how you can represent everything with lambdas... 

1, 2, 3, true, false, equals, if, list

Basically build anything out of nothing

https://www.youtube.com/watch?v=VUhlNx_-wYk


Now you might see there can be quite a bit of power to lamdas,
check out how this has all been around for decades.
In 1977 the Turing award winner (equivalent to Nobel prize for CS) for 
creating Fortran, in his 'acceptance paper' said we were doing it all wrong,
and were working at way too low levels of abstraction.

http://worrydream.com/refs/Backus-CanProgrammingBeLiberated.pdf

## Lets Go Crazy!

[Pure insanity](https://github.com/sjsyrek/presentations/blob/master/lambda-calculus/lambda.js)

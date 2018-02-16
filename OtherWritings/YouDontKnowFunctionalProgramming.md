# You Don't Know Functional Programming

Recently I've been part of several discussions where Functional Programming has come up, and it seems like there's a bit of a misconception of what FP is all about. Some have said: "Well some devs prefer using the object oriented way and others like it the functional way", others have said FP is about using recursion or first-class functions or higher-order functions or pure functions or immutible objects.

To me, this seems to expose some fundamental misconceptions as to what FP is and why it is an incredibly powerful paradigm to understand and use.

My objective is not to 'define' functional programming. Some have said it [may be even less well defined than object oriented programming](https://www.quora.com/What-are-some-myths-about-functional-programming-and-functional-programming-languages). Rather I'd like to expose here some of the deeper concepts that underly the paradigm.

Usually when discussing technology we talk about features: "It has A and B and C and so it is GREAT!". Half the time I don't even understand the words they are using! Instead lets talk about the essense, origins, and objectives of a technology, so we can make better, more informed decisions.

I've found that using FP makes code more:
* Reusable
* Reliable
* Testable
* Readable
* Maintainable

So let me show you why.

The concepts here are just the FP fundamentals. Its not desinged to be an intro to FP, rather an explanation of why the concepts are incredibly powerful.

Below, we'll dive into the fundamentals of the functional programming style and features in some languages. On the way you'll see some of the features you've heard of or worked with before, but we'll approach them from a different direction. Hopefully I'll provide the 'why' in "Why should I care about Functional Programming?" and why so many people these days are making such a fuss about it.

## The Rules of Mathematics

Believe it or not, first-class functions, or the ability to pass functions around, does not define the functional style or a language as a functional programming language. Though first class functions are important, we aren't talking about them when we're talking about 'functional' programming.

Functional Programming is about using the underlying rules of mathematics to prove our programs are correct.

WAIT!! DON'T LEAVE!!

Don't be scared, its different than you might think.

We're **not** talking about the scary parts of math, like calculus and differntial equations. 

Its also **not** about simple arithmetic, like addition or subtraction.

Rather, its the use of the concepts that underly mathematics which allow arithmetic and calculus to work. Most of these concepts you learned in basic high school math.

You may remember the associative property. With it we can group variables in different ways with addition and multiplication, while ensuring the outcome remains the same:

```
(a + b) + c = a + (b + c)
```

Or the 'commutative' property, where we can swap the order of items:

```
a * b = b * a
```

When people say "Functional Programming is like Math", they are actually talking about using the underlying rules of math, like associativity, to create reliable code. They are not talking about just addition and subtraction, or doing financial calculations. They are talking about the rules that govern all mathematics.

This branch of mathematics called Category Theory. It's a very abstract branch of pure mathematics which essentially focuses on the study of 'universal' math concepts, like the associative and commutative properties. 

BUT WAIT! I wouldn't suggest going off to read about it though. Though I haven't explored it much, but from what I've seen its a pretty wild jungle and only a small set of category theory is applicable to software development. (If you are interested in learning more though, there's [a great set of articles here to read](https://bartoszmilewski.com/2014/10/28/category-theory-for-programmers-the-preface/).)

Back to it.

We often talk about how 'new' the field of software development is and how ill prepared we are compared to other engineering professions. But what if we could use the mathematical rules that have been developed over thousands of years[1] to prove what we are building will work? 

In fact we can. And that's what we'll dig into.

[1]("The Egyptians used the commutative property of multiplication to simplify computing products." -Wikipedia)


## Expression Oriented Programming

You've heard of Object Oriented Programming. Here's a new one for you: Expression Oriented Programming.

Whether we want it to or not, most of our code ends up looking like this:

```
var a = m + ", hello."
var b = n + " World "
a = a.toUpper();
b = b.toLower();
var p = a + " " + b;
var c = p.trim();
```

We give the computer a list of statements to execute, and hope we didn't forget an important step. There's nothing 'wrong' with this, but it requires we 'think like the computer', maintain lots of variables in our head, and creates many places for bugs to creap in.

We can improve on this. Let's first work through some simple math examples, then come back to this code.

In math you have an expression like:

```
c = sqrt(a^2 + b^2)
```

Notice how the whole operation fits on one line? Also notice there are no variable's being created or assigned. 

Its just one simple reusable equation.

What if we extended the equation:

```
let a = x + 1
let b = y + 3
c = sqrt(a^2 + b^2)
```

Let's now use the substitution property to 'reduce' it:

```
c = sqrt((x + 1)^2 + (y + 3)^2)
```

Is there anything different in this code? Is the outcome different? Did ANYTHING change? No. 

The result is exactly the same, we've just taken two expressions `x + 1` and `y + 3` and substituted them for `a` and `b` in the third expression. 

This is a critical point.

In an imperitive language, we'd 'evaluate' the result of `a` and assign the result to a memory space. Then evaluate `b` and do the same. Finally, we'd retrieve `a` and `b` and pass them into the final statement and evaluate it.

In FP languages, a slightly different approach is taken.

`let` does not evaluate `x + 1` then 'assign' the result to a memory space. Rather it is just saying that `a` represents the expression `x + 1`, and you can swap or substitute one for the other.

In FP-land, one of the first steps of compilation is the simplification of expressions into more concise expressions, or to put the two expressions(`a` and `b`) into the third. 

The code is written for readability, but the compiler simplifies the expression down into something more compact.

In a language like Elm or Haskell, you might see a slightly different syntax like this:

```
let 
	a = x + 1
	b = y + 3
in
	sqrt(a^2 + b^2)
```

Don't be scared of the syntax, its the same thing as before. Between `let` and `in` are one or more expressions, which can be used in the expression after `in`. When the compiler runs, it will reduce to a single statement:

```
sqrt((x + 1)^2 + (y + 3)^2)
```

Functional programming language compilers know about substitution, reduction, and other properties, and use them where possible. 

What if we could use similar ideas in our imperitive code to improve the reliability and maintainability of our code?

Lets look at the earlier example:

```
var a = m + ", hello."
var b = n + " World "
a = a.toUpper();
b = b.toLower();
var p = a + " " + b;
var c = p.trim();
```

Instead we could write something like:

```
let
	a = (m + ", hello.").toUpper()
	b = (n + " World ").toLower()
in 
	(a + " " + b).trim();
```

Which the compliler would then reduce down to a single expression:

```
((m + ", hello.").toUpper() + " " + (n + " World ").toLower()).trim();
```

Using this methodology allows us to create a series of small, reusable, testable expressions that we can group into ever larger expressions. Because we know the small expressions work, we have strong guarentees that the larger expressions will work.

When you start working in functional languages, the faster you can get used to the idea that everything is an expression, the faster you will be able to pick up the language. From what I have seen, creating a program out of all expressions is the essence of Functional Programming.

When everything is an expression (and expressions can be composed of sub-expressions) we build in significantly more reusability, improve maintainability, improve readability, and most importantly start changing the way we think about the problems we are tackling.

## Use of Expressions

Moving forward, you will see us taking this small idea and building on it. All the other tools of functional programming, like pure functions, immutible data, and composition, grow from the simple idea of expressions. They are the **tools** that become valuable in expression oriented programming (or functional programming), but they are **not** the essense of it.

Another way to put it, expressions are the simplest unit in FP. Things like pure functions, immutible data, and composition, are tools or concepts used to put larger programs together and send data through them.

Expressions are at the heart of FP. In functional languages virtually everything you write will be an expression of some type, or reduce down to one.

So when someone says Functional Programming is like math, realize they are saying: "The smallest functional unit in math is an expression. So if we use expressions we know to be true, we can use the mathematical rules developed over thousands of years to combine these expressions into programs which are provable and operate in a reliable, consistent manner."

## Associative Property

So from here on out, all our code will use one or more expressions, so we can take advantage of the previously discussed perks.

So why are the ideas of Category Theory helpful? Lets look at the Associative property first.

Both addition and multiplication are functions that abide by the associativity property:

```
(a + b) + c = a + (b + c)
```

So maybe other functions can also abide by the associativity property.

Lets look at the concatenation of strings. Does it abide by the associativity property?

```
("a" + "b") + "c" = "a" + ("b" + "c") = "abc"
```

Yes, string concatentation **does** abides by the associative rule!

Does this seem basic? Maybe, but remember many of the most powerful concepts actually derive from quite simple ideas.

Why is this useful?

Lets take a list of strings and use the `join` function to combine them into a single list:

```
let l = ["a", "b", "c", "d"];
list.join(""); //"abcd"
```

Simple right? We'll take `"a"` and concatenate `"b"`, then concatenate `"c"`, etc.

Here's the kicker, pay close attention:

What if we have one billion strings that we want to combine? We don't want to do that in a single loop, it would take a seriously long time. Instead, we might want to break down the list into two or more parts, concatenate each part, then combine the parts:

```
//step one, create two or more lists
("a" + "b") + ("c" + "d")

//step two, concatenate each list
("ab") + ("cd")

//step three, concatenate all lists together
"abcd"
```

Because we can use the associative property, we can first can create multiple lists, concatenate each list, then concatenate all the lists.

To do this we could either create or use a library that ran the `join` function in parallel, and maybe call the function `pjoin`, for parallel join.

```
let l = ["a", "b", "c", "d", ...];
list.pjoin(""); //"abcd..."
```

The `pjoin` function would allow us to rely on a mathematical propery thats been know for 1000s of years, the associative propery, to combine small parts into larger parts. 

Though we may not need `pjoin` in our daily work, the concept of our compiler knowing about and respecting the associative property allows us to do some very powerful things, in a very safe way. 

The value here comes from the gaurentee we get. When we are gauranteed items will combine in a consistent way we can build applications we know will work. Applications will perform the same calculation and return the same result EVERY time.

This is one of the essential characteristics of functional programs. Guarenteed results regardless of the inputs.

## Functions

We've now established a nice 'baseline'. Expressions are valuable and using expression combining rules result in more robust code.

But once you have an expression how do you make it reusable? Well, as you might expect we'll use a function. 

But a math function is a bit different than the methods or subroutines you're used to.

In math, all functions abide by a set of rules, but we, as programmers, don't have to just use the rules for numbers.

As Wikipedia states: "a function is a relation between a set of inputs and a set of permissible outputs with the property that each input is related to exactly one output."

So if we have an `isEven` function:

```
function isEven(n) {
   return n % 2 == 0;
}
```

If we 'apply' the `isEven` function to `4` (or call the function with `4` as the first parameter), we will always get an output of `true`. And `5` will always equate to `false`.

(Note: in math you 'apply' a function to a value or input, so FP uses the same language. In OO we 'call' a method. It takes a minute to get used to, but is just a small terminology hurdle to get over.)

Another way to think about it, is that an input `n` to a function could be put into a dictionary/hash as the key, and the output could be added as the key's value. Then, if you run the function again with the same input, you can lookup the result in the dictionary and not have to run the function again.

So we could build a dictionary like this:

```
//input                   //output
 2        (n % 2 == 0) =  true
 3        (n % 2 == 0) =  false
 4        (n % 2 == 0) =  true
 5        (n % 2 == 0) =  false
```

This process is called 'mapping' from the input(domain) to output(codomain).

When this quality of a function is true, the function can be deemed a 'pure function'.

'Pure functions' are incredibly important in functional programming, as you may have heard. 

Why is this useful?

There are many reasons, but lets cover two:

1) When testing a function it will do the same thing every time
2) We can optimize the function

### Testing

When a function returns the same output based on the same input we can test that function very easily. When testing pure functions we don't have to worry about complex setups to run a test. Testing has gained incredible traction in the last decade and so pure functions allow you to say to your boss: "Yes, I unit tested my code".

### Optimization

Lets use the factorial problem as an example, but this applies to any CPU intensive operation.

```
funtion factorial(i){
	if (i == 0)
        return 1;  
    else
        return (i * factorial(i - 1));
}
```

If we execute `factorial(10)` the calculation will be incredibly fast. But what happens when we need to execute with large numbers? Like `factorial(10000)`. That can take a lot of CPU cycles.

But because we know that `factorial` returns the same thing every time, we can store the result for `i` and reuse the result! This process is called memoization, or "to memoize" a function.

So if we run `factorial(10000)` we will execute the function and store the result in a dictionary. So the next time we run `factorial(10000)` we look up `10000` in our dictionary, and since it exists, return it, eliminating all of the CPU processing.

Even better... if we run `factorial(9999)` because this is recursive, when we calculated `10000` we also calculated `9999` and so already have the value stored! 

If we didn't have the consistency of a one to one mapping (the input to the output), which is a challenge in much of our imperitive code, we could not do this. But when we build our systems out of reliable pieces like this, we gain big advantages.

### Function vs Method

In OOP we usually use the term 'method' to represent a routine attached to an instance of an object. In a method, you usually access some data attached to the instance of that object. 

In FP, we try and make most of code 'pure functions' and attach them to modules. You can also think of functions in OO as `static` functions attached to an object.

A function should always return the same output when supplied the same input. A method does not have those same gaurantees. Where it makes sense, I'd suggest trying to start integrating this differentiation into the language you use.

## Function Composition

Now we have a reliable way to put an expression into a reusable form: the function.

The function will always return the same output, based on the input supplied.

Once we have that reliability, we can now start to combine functions in a consistent and reliable way. And because our lower level functions gaurantee reliability, when we combine two functions, the output should also be gauranteed.

Lets look at an example:

```
function f(x) {
	return x + 1
}
function g(y) {
	return y + 2
}

g(f(1)) //4
```

We know `f` will always increment by 1, and `g` will always increment by 2. So if we 'compose' or combine `f` and `g`, we know we will get this type of outcome:

```
//input		//output
1			g(f(1)) = 4
2			g(f(2)) = 5
3			g(f(3)) = 6
4			g(f(4)) = 7
```

Since our lower functions are reliable, we can now combine or 'compose' functions that are reliable. `1` will always return `4`. `3` will always return `6`.

Again, this may seem very basic, but the simplest things are sometimes the most powerful because of the simplicity. Simplicity often `==` reusability.

Lets take a look at ReactJS to prove this out. With the ReactJS library, you can combine two functions together to create a third.

```
let subcomponent = name => `<div>Name: <span>${name}</span></div>`
let component = sub => `<div>Person: ${sub}</div>`
let topLevel = name => component(subcomponent(name))
```

Here we can see that we've combined a subcomponent with a component. This code is:

* Reusable
* Testable
* Readable

When doing something like `component(subcomponent(name))` this can become hard to read very quickly though, and so we use a `compose` function to help us:

```
let topLevel = name => compose(component, subcomponent(name))
```

But then a new requirement comes along, and we need to accept multiple names. Instead of changing everything, we just need to make a couple tweaks:

```
let subcomponent = name => `<div>Name: <span>${name}</span></div>`
let component = subs => `<div>${subs.length>1?'People':'Person'}: ${subs}</div>`

let topLevel = names => compose(component, names.map, subcomponent)
//same as:
let topLevel = names => component(names.map(subcomponent))
```

We needed to change the `component` to handle multiple names, and we passed the `list.map` function as the second argument to `compose`. 

Though this may look a bit unfamiliar, we haven't significantly increased the complexity of the code. There are still just three lines of code, no looping is involved, and we just need to update our unit tests.

Chaining these functions together is quite simple and reusable. It creates a quite powerful abstraction that can be used over and over without impacting other functionality.

## Conclusion

Hopefully at this point you now have a slightly better appreciation for the low level rules or tools that govern how functional programming works, and how those tools can be used to build on each other. 

Some of you might ask: "But how do we use these tools to create real software".

My answer is: Start using expressions instead of statements. Start combining expressions into larger ones. Start by using functions instead of methods.

I cannot show you the path, you have to find it. But starting to use the tools we've discussed here will start opening doors which I have found lead to code clarity, simplicity and reliability.

It has taken quite a bit of work for me to get here, but hopefully this provides you a shorter circuit to see how and why FP can benefit your daily coding life.

If you are a math nerd and interested in learning more about category theory, check out [Category Theory for Programmers](https://bartoszmilewski.com/2014/10/28/category-theory-for-programmers-the-preface/). Its a great intro without having to read things like:

> Bicategories are a weaker notion of 2-dimensional categories in which the composition of morphisms is not strictly associative, but only associative "up to" an isomorphism.

Barf!

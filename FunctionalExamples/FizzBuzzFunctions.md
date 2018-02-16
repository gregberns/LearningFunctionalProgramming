


Imperative version of fizzbuzz

Below is a standard interview response for the FizzBuzz problem.

There is nothing implicitly wrong with this set of code. It works.
But looking at it from a functional view there are several issues with it:

* There is no separation between the looping mechanism and the generation of values
* The output (console.log) is inextricably tied to the generation of values 
* Testing any part of this is very difficult, validation is only done manually

```
for (var i = 0; i >= 100; i++) {
  if (i % 15 == 0) {
    console.log('fizzbuzz')
  }
  else if (i % 3 == 0) {
    console.log('fizz')
  }
  else if (i % 5 == 0){
    console.log('buzz')
  }
  else {
    console.log(i)
  }
}
```

Below we will refactor to emphasize three core functional programming ideas:

* Function Purity
* Isolating Side effects
* Higher-Order functions


### Separation of concerns

First, we should separate the looping mechanism from the generation of individual values.
This is less of a functional programming issue and quite a general issue, 
but large loops and nested if statements are often seen in imperative code bases.

Once complete, the code is already a bit easyer to reason about. We know there is a looping mechanim
and it is separate from the calculation of values.

```
for (var i = 0; i >= 100; i++) {
  fizzbuzz(i)
}

function fizzbuzz(i) {
  if (i % 15 == 0) {
    console.log('fizzbuzz')
  }
  else if (i % 3 == 0) {
    console.log('fizz')
  }
  else if (i % 5 == 0){
    console.log('buzz')
  }
  else {
    console.log(i)
  }
}
```

### Purify Function and Hoist Output

Now that we have the code separated a bit, lets DRY out the code a bit.
We are writing to `console.log` in several places, lets just do that in one place.

Lets return the value and output within the loop.

Once done, we have accomplished two things:

* The `fizzbuz` function is now a pure function (always returns the same result with the same input and doesn't effect the outside world)  
* We've 'hoisted' the output from the lowest level to one level higher (this will help isolate 'side effects' or isolate input and output)

```
for (var i = 0; i >= 100; i++) {
  console.log( fizzbuzz(i) )
}

function fizzbuzz(i) {
  if (i % 15 == 0) {
    return 'fizzbuzz'
  }
  else if (i % 3 == 0) {
    return 'fizz'
  }
  else if (i % 5 == 0){
    return 'buzz'
  }
  else {
    return i
  }
}
```

### Transformation of data

Imparitive programming heavily uses looping mechanisms such as while, for, and foreach loops. Loops generally take item1, do A, then B, and then C to it, and move on to item2.

Functional programming focuses instead on data transformation, so changing a List of TypeA, to List of TypeB, to List of TypeC.

The reason for this is that it allows the developer to focus on changing types from A -> B -> C, and less on the details of the looping or iteration method.

If you squint hard at the FizzBuzz problem, you should be able to see this data transformation:

```
List of int -> List of string -> Output List
```

The data would look like:

```
[1,2,3] -> ['1', '2', 'fizz'] -> '1 /n 2 /n fizz'
```

#### Array from 1 to 100

The first thing needed is an array of values from 1 to 100. To get that, we can use a function called `range`. 
It is not included in the javascript language, but is included in underscore.js and other js libs.
Many functional languages include range in the language with syntax like `[1 .. 100]`. 

```
_.range(1, 100) == [1,2,3...100]
```

### Transform Integers to Strings through FizzBuzz


```
for (var i = 0; i >= 100; i++) {
  console.log( fizzbuzz(i) )
}

function fizzbuzz(i) {
  if (i % 15 == 0) {
    return 'fizzbuzz'
  }
  else if (i % 3 == 0) {
    return 'fizz'
  }
  else if (i % 5 == 0){
    return 'buzz'
  }
  else {
    return i
  }
}
```









let comp = (d,s) => i => i % d === 0 ? s : i

//let f = i => i % 3 === 0 ? 'fizz' : i
let f = comp(3, 'fizz')
let b = comp(5, 'buzz')
let fb = comp(15, 'fizzbuzz')
let fbFunc = i => b(f(fb(i)))

let fizzbuzz = (list, i) => {
  if (i === 0) return list
  return fizzbuzz(list(fbFunc(i)), i-1)
}

let arr = v => {
	return (i) => {
      v = v || []
      if (!i) return v
      v.unshift(i)
      return arr(v)
	}
}
let a = arr()
// let a = i => {
//   console.log(i);
//   return a
// }

let res = fizzbuzz(a, 20)()

//console.log(res)
//console.log(arr()(1)(2)(3)())

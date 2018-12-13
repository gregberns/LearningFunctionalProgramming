module BasicSyntax where

import Prelude

import Undefined


{- Introduction to PureScript syntax and functional concepts 

  In the following examples,
    * Fill in the '__' blanks with actual values
    * attempt to reuse previously defined functions. 
-}

{- Define a constant
   
   Read `xx :: Int` as "`xx` is defined as an Integer"
   And "`xx` is 5"
  
   `xx` 'represents' 5.
   5 and `xx` are interchangable
-}
xx :: Int
xx = 5

{- Define the `plus` function

  Read as `add` takes an `Int` and `Int` as parameters 
  and returns an `Int`

  The `plus` implementation takes an x and y parameter,
   adds them together, and returns the result

  Objective: Replace `__` with a parameter to
   make the function work

  > plus 5 8
  13

  C# syntax
  public int plus(int x, int y) { 
    return x + y;
  }

  ES6 Syntax:
  const plus = (x, y) => x + y;
-}
plus :: Int -> Int -> Int
plus x y = x + __


{- Define the string concat function
  
  Read as: `concat` takes two strings and returns a string
  
  `concat` takes `a` and `b` which are strings, 
  concats them, and returns a string

  > concat "Hello " "World!"
  "Hello World!"

  C# syntax
  public string concat(string x, string y) { 
    return x + y;
  }

  ES6 Syntax:
  const concat = (x, y) => x + y;
-}
concat :: String -> String -> String
concat a b = __ <> __

{- Use the `show` function to turn a value into a string representation.

  > showConvertsToString 5
  "5"

  Note: use `show` to experiment with functions below 
  to make them more interesting.
-}
showConvertsToString :: Int -> String
showConvertsToString i = show i


{- A function called `f`, takes an Int returns an Int

  > f 2
  7
-}
f :: Int -> Int
f a = a + 5

{- Define an 'inline' function, also known as a 'lambda'

  This is similar to Javascripts lambda, just with small
  syntactic differences
  `var g = a => a + 77`

  > g 5
  15

  Question: What is the difference between `f` and `g`?
  Answer: Nothing. They are exactly the same.
    `g` just uses an inline style
-}
g :: Int -> Int
g = \a -> __ + 10

{- What do the parenthesis change?

  > let hh a = h 3
  > hh 4
  14

  This is 'partial application'. 'Apply' one argument
  then later apply another.

  Intution: "When we supply the first Int, we get 
             back a function `Int -> Int`"

  This is important because all functions in
    PureScript take one argument at a time.

  Example in JavaScript:
  function h(i){
    return function(j){
      return i + j
    }
  }
-}
h :: Int -> (Int -> Int)
h a b = (a + b) * 2

{- In PureScript, functions are 'first class citizens',
   like in JavaScript, so they can be passed around.

  `i`s first parameter takes a function, which takes an 
  Int and returns an Int. Once supplied, the function evaluates.

  > i g
  16

  What happened?
  `g` was applied as the first parameter `a`
  So in `i`s body we can replace `a` with the body of `g` 
    `(\a -> a + 10) 6`
  Now we can apply 6 to the lambda and we get:
    (\6 -> 6 + 10)
    6 + 10
  Which evaluates to 16
-}
i :: (Int -> Int) -> Int
i a = __ 6


{- Lets talk about 'Higher Kinded Types'
  These are known in C# as Generics
  You can ignore the terms for now, just focus on the intuition

 `j` is going to take an Int, then some type `x`, 
   then return a value, where the type of `x` are the same
 
 (Disregard the `forall x.` syntax for now. But the parens are important.)

  > j f
  11

  > j (int -> show int)
  6

  C# Version
  T j<T>(Func<Int, T> fn) {
    return fn(6);
  }
-}
j :: forall x. (Int -> x) -> x
j k = k 6

{- Why are Higher Kinded Types (Generics) valuable?

  In FP there's a function called `identity` or `id`.
  What can we do with it?
  What can't we do with it?

  > id "hello"
  "hello"
  
  > id 5
  5

  In C# what could a method with this signature do?
  T id<T>(T thing)

  Answer: Anything. Change 'thing', 
    write to the database, launch a missle.

  In Purescript, there is one and only one implementation.

  Types allow us to 'reason' or think about the possible
  things a function can do when run.
-}
id :: forall x. x -> x
id a = a

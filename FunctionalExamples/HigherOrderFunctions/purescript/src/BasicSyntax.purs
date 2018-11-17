module BasicSyntax where

import Prelude


-- Basic Syntax Overview

--Define a constant
-- read: `x` is defined as an Integer
x :: Int
-- `x` is 5
x = 5

-- Define the `add` function
-- read: `add` takes an Int and Int as parameters and returns an Int
plus :: Int -> Int -> Int
-- `add` takes an x and y parameter, 
--    adds them together, and returns the result
plus x y = x + y

-- Define the `string concat` function
-- read: `concat` takes two strings and returns a string
concat :: String -> String -> String
-- `concat` takes `a` and `b` which are
--    strings, concats them, and returns a string
concat a b = a <> b

-- Define a function called `f`, takes an Int returns an Int
f :: Int -> Int
-- read: "Given a", return a + 5
f a = a + 5

--Inline Functions - AKA: a 'lambda'
g :: Int -> Int
g = \a -> a + 10

-- This is similar to Javascripts lambda, just syntactically different
-- var g = a => a + 77

--Question: What is the difference between `f` and `g`?
--Answer: Nothing. They are exactly the same, 
--  they just are syntactically different

-- Now, lets step it up...

-- Do the parenthesis change anything?
h :: Int -> (Int -> Int)
h i j = (i + j) * 2

-- No, but... 
-- What is the purpose of them here?
-- Think, "When we supply the first Int, we get back a function `Int -> Int`"

-- This is important because all functions in PureScript take one argument at a time.
-- When the first argument is supplied, `i`, a function will be returned
-- Then the second argument can be applied to that function, 
-- and the function body will be evaluated
-- Example in JavaScript:
--
--   function h(i){
--     return function(j){
--       return i + j
--     }
--   }

--In PureScript, functions are 'first class citizens', just like in JavaScript
-- So they can be passed around. So lets look at that.

-- `i` as the first parameter takes a function that takes an Int and returns an Int
-- Once supplied, the function will evaluate
i :: (Int -> Int) -> Int
i k = k 6

--So lets use this function and use a function we created above, `g`:  g = \a -> a + 10
--  In the REPL type:
-- > i g
-- 16

--What happened?
-- `g` was applied as the first parameter(`k`) to the function `i`
-- So in `i`s body we can replace `k` with the body of `g` 
--  `(\a -> a + 10)(6)`
-- Now we can apply 6 to the lambda and we get:
-- 6 + 10
-- Which evaluates to 16, obviously

--Lets do the same with `f` on the REPL
-- > i f
-- 11

--Make sense?


-- Lets talk about 'Higher Kinded Types'
-- These are known in C# as Generics

-- `j` is going to take an Int, then some type `x`, 
--   then return a value, where the types of both `x`s match
-- (Disregard the `forall x.` syntax for now. But the parens are important now.)
j :: forall x. (Int -> x) -> x
j k = k 6

-- In the repl
-- > j f
-- 11

-- Identity
-- In FP we have a function called 'Identity'
-- It seems useless, but takes a value and returns the same value
-- Because of Higher Kinded Types, we can write this once, period.
-- We don't need to write this for strings and ints and bools
id :: forall x. x -> x
id a = a

-- In the repl
-- > id "hello"
-- "hello"
-- > id 5
-- 5



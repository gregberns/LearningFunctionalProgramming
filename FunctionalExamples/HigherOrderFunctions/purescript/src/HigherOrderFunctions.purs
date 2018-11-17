module HigherOrderFunctions where

import Prelude


--If you just went through the `BasicSyntax` the first
-- couple functions will be familiar

--Lets start with a simple function
m :: Int -> Int
m a = a + 5

--Now we can define a second function
n :: (Int -> Int) -> Int
n b = b 6 

-- In the repl
-- > n m
-- 11

--We've now passed one function `m` into another function `n`

--Instead of passing in a function, lets return a function

p :: Int -> (Int -> Int)
p i = (\j -> i + j)

-- In the repl
-- > (p 3) 6
-- 9

-- Lets step it up a bit...

-- `q` takes two parameters:
-- * a function `f` which takes an Int and returns an Int
-- * an Int
-- And returns an Int
q :: (Int -> Int) -> Int -> Int
q f a = f a

-- In the repl
-- > q m 10
-- 15

-- In JavaScript this looks like:
-- function q(f){         // `f` takes an Int and returns an Int
--   return function(a){  // `a` is an Int
--     return f(a)        // `f` takes `a` (an Int) and returns an Int
--   }
-- }


--Now lets do the same thing but make all of our parameters 'generic'

-- `r` takes two parameters:
-- * a function `f` which has one parameter of type `a` and returns a type of `b`
-- * a value of type `a`
-- And returns a value of type `b`
-- Note: `a` and `b` **can** be the same type, but they dont need to be
-- (Ignore the `forall a b.` syntax for now)
r :: forall a b. (a -> b) -> a -> b
r f a = f a

-- In the repl
-- > q m 10
-- 15

-- In the repl
-- > q (\a -> a + 20) 10
-- 30

-- In the repl
-- > r (\a -> a <> " World!") "Hello"
-- "Hello World!"


-- Woah! We just used the same function `r` to handle Ints and Strings


-- Now lets take two values, and return a function
s :: forall a b c. a -> b -> (a -> b -> c) -> c
s a b f = f a b

-- In the repl
-- > s 3 5 (\a b -> a + b)
-- 8

-- In the repl
-- > s "Hello" "World" (\a b -> a <> " " <> b)
-- "Hello World"

-- In JS
-- function s(a) {
--   return function(b) {
--     return function(f) {
--       return f(a, b)
--     }
--   }
-- }
-- Or more concisely
-- function s(a, b, f) {
--   return f(a, b)
-- }
-- Or ES6
-- var s = a => b => f => f(a, b)


-- Hopefully your still with us...


-- Lets take another step up in complexity

-- Lets define a function that takes two functions
--Define two functions to use
t1 :: Int -> Int
t1 a = 10 - a

t2 :: Int -> Int
t2 b = b + 15

-- `t` takes
-- * a function from `a` to `b`
-- * a function from `b` to `c`
-- * a value which is of type `a`
-- and returns a value of type `c`
t :: forall a b c. (a -> b) -> (b -> c) -> a -> c
t fa fb a = fb (fa a)

-- Oh shit... that might have been a stretch. 

-- repl
-- > t t1 t2 6
-- 19

-- Lets illustrate in a different way.
-- Remember simplification in math? Lets do that.
-- We can replace `t1` and `t2` with the bodies of those functions
-- t t1 t2 6 = (b + 15) ((10 - a) 6)
-- t t1 t2 6 = (b + 15) (10 - 6)
-- t t1 t2 6 = (b + 15) 4
-- t t1 t2 6 = 4 + 15
-- t t1 t2 6 = 19

-- And again in JS
-- function t(t1) {
--   return function(t2) {
--     return function(a) {
--       return t2(t1(a))
--     }
--   }
-- }
-- Or ES6
-- var t = t1 => t2 => a => t2(t1(a))


-- If you're still with us, congrats.
-- One last challenge.

-- Lets take two functions and return a function
-- Notice its very close to what we had in `t`,
-- but instead of taking an `a` as a parameter, 
-- we wrap everything in a lambda function and return it
tt :: forall a b c. (a -> b) -> (b -> c) -> (a -> c)
tt fa fb = (\a -> fb (fa a))

-- repl
-- > (tt t1 t2) 6
-- 19

-- Wait!! Is the JS any different than before?
-- Notice how the PureScript parameters changed...
-- function t(t1) {
--   return function(t2) {
--     return function(a) {
--       return t2(t1(a))
--     }
--   }
-- }
-- Or ES6
-- var t = t1 => t2 => a => t2(t1(a))


--Last question, whats the difference between `t` and `tt`?


-- Next you'll want to look at how we can use
-- Higher Order Functions on different data structures.
-- But first need to understand what types of data structures 
-- we have available to us and their syntax.


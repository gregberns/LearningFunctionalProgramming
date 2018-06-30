An Intution for List Folds

a list is constricted with Nil and Cons

Nil :: List a 
Cons :: a -> List a -> List a

foldr and foldl are very different functions

foldl
f :: b -> a -> b
can be thought of as the same as a loop
can be used to sum list
an infinite list will never return
Foldl is all of your loop duplication factored out (`for(i in...)`)

almost does map, but the problem is the returned value is revered. 
the issue is when you run against infinity and take 10 it'll never return

foldr
f :: a -> b -> b
Does constructor replacement
`reduce`
used to check list of bools are all true (conjunction) (binary closed operation)
This is called a monoid - the pair of && and True - closed binary operation 
example: append two lists

foldr :: (a-> b-> b) -> b -> t a -> b
cons:: a -> [a] -> [a]
--see how the functions line up

foldr does constructor replacement!!

can map a function on a list

"do this then that" == "that . this"

`:! clear`

## Effectful values

liftA2 - puts f around a's

foldr (liftA2 (:)) (return []) (Just 5 : Just 6 : [])

foldr (liftA2 (:)) (return []) ((+5) : (*6) : []) 88

take 4 (foldr (:) [] [1..])  --this will work

foldr const 99 [1..] --???? returns 1, why

foldr is associative but the order in which it folds is arbitrary
 - it doesnt start from the right, but it does **associate to the right**

## Summary
foldl - loops
foldr - constructor replacement


# Functional Programming for Non-Programmers

Why is functional programming something 'the business' should care about?

Its not and it shouldn't care about it.

Organizations should care about:
* Software that works consistently
* Software that fails infrequently
* Software that when it fails is easy to fix and is easy to understand why it failed

Programmers need to write programs that work consistently and predictably.


## Lets establish some basic syntax

```
x = [1,2,3]

// append takes the list, adds an item, and returns a new list with the item added
// x is the list
// 4 is the item to add to the end of the list
// y is the new list
y = append x 4

// y = [1,2,3,4]
```

## This is how 'normal (imperative) programming' languages work

```
x = [1,2,3]

// addItem takes the list and modifies the existing list
// x is the list
// 4 is the item to append
addItem x 4

// x = [1,2,3,4]
```

Why is this a problem? 

Its not, unless you screw up the order...

```
x = [1,2,3]

addItem x 5
addItem x 4

// Oops, we actually meant to have 4 then 5
// x = [1,2,3,5,4]
```

## Execution Order

The order in which things are executed is **very** important.

How can we guarentee the order in which items are added?

```
x = [1,2,3]

z = append (append x 4) 5

// or a different way to write it...
// y = append x 4
// z = append y 5

// z = [1,2,3,4,5]

```

**Note** the whole `y` expression can be substituted without changing how the program executes

This is called referential transparency, and is **the** most important idea of functional programming.

## How to screw things up

Another way to look at it.

What if we want to add items to a list, then pass the list onto another function?

```
x = [1,2,3]

// `goDoSomethingWithLists` takes two lists

// With `addItem` now 'order of evaluation' is very important
// The first `addItem` will supply [1,2,3,4]
// The second `addItem` will supply [1,2,3,4,5]
goDoSomethingWithLists (addItem x 4) (addItem x 5)

// But with `append`
// The first `addItem` will supply [1,2,3,4]
// The second `addItem` will supply [1,2,3,5]
goDoSomethingWithLists (append x 4) (append x 5)

```

Questions to answers:
* What are the parameter value when passed in?
* What if the language is a pass by value? What if its pass by reference?
* Does the languages order of evaluation matter?

## What if the list is changed somewhere else

```
x = [1,2,3]

// What if it does this?
goDoSomethingWithList x = addItem x 123456789

goDoSomethingWithList x
addItem x 4

// Oops, I didn't know `goDoSomethingWithList` would do that!!
// x = [1,2,3,123456789,4]

```

## OMG What are you going on about!

This is what we do today:

```
balance = 50

credit x bal = 
  bal = x + bal

debit x bal = 
  bal = bal - x

autopay pay bal = 
  debit pay bal  
  saveNewBalance bal // Oops... the account doesnt have $100, Overdraft!
  credit pay bal
  saveNewBalance bal

autopay 100 balance
```

If we have the ability to change (mutate) the balance on the fly, a fault can occur if we screw up the order.

But if we say: "We are going to calculate a new balance" and the new balance is saved **after** all the calculations....

```
balance = 50

credit x bal = x + bal
debit x bal = bal - x

autopay pmt bal = debit pmt (credit pmt bal)

newBalance = autopay 100 balance

saveNewBalance newBalance

// Could actually be written as...  (Think math substitution)
saveNewBalance (autopay 100 balance)               // start replacing expressions
saveNewBalance ((debit 100 (credit 100 balance)))
saveNewBalance (((credit 100 balance)) - 100)
saveNewBalance (((100 + balance)) - 100)
saveNewBalance (balance + 100 - 100)          //commutative
saveNewBalance (balance)
```

Because the code above abides by math principles, instead of modifying the values directly, we can use rigorously use simplification rules before the `saveBalance` occurs.

## What does this provide?

Remember the associtive law from 7th grade math?

```
(a + b) + c = a + (b + c)
```

This law provides us guarentees as to how things get combined.

What if we could use concepts like this throughout our programs?

# Stop Using Null as an Empty Object

There are many cases where we use `null` to represent an empty value. 

So we request a value:

```
var person = _personRepository.Find(id);
```

But then are expected to know that the `person` could be null/empty.

``
let person = _personRepository.Find(id);

person.Name.ToLower() //Oops, NullException thrown here...
```

Today, many of our languages are strictly typed (TypeScript, C#, etc.), and so should help us identify when things can be empty or null. For example, C# has a `Nullable<T>` type that allows us to identify values early that can/will be null, so we can handle them accordingly.

Lets take the idea of 'null-ability' to the next level and really use it in our type system.

## Introducing Maybe

If we look at the `_personRepository.Find` request, we discover that there can be only one of two values:

* 'Some' person was found
* 'None' were found

```
let person = _personRepository.Find(id);
```

So how can we model this situation in English?

"When `personRepository` is called, maybe some person will be found or no person will be found."

In code, we can model it similarly as `Some` person will be found, or `None` will be found.

Another way to think about it: 
* Maybe we get a person: Maybe<Person> = Some(person)
* Or Maybe no person is returned: Maybe<Person> = None()

Another way to think of it is that `Maybe` is a 'list' with a maximumm of one item. 

The list can contain either be 'Some' which means it has one item, or 'None' which means no items in the list.

We'll use the Generic syntaxt of TypeScript/C#

```
type Maybe<Person> = {}

function Some<Person>(Person obj) {
	return Maybe<Person>(obj)
}

function None<Person>() {
	return Maybe<Person>()
}
```

## Why is the Null Dangerous

Let's find a more powerful example where null becomes dangerous: 

If we request a person's name from a form, but they are't required to supply it.

Traditionally, we'd do something like this:

```
let person = _personRepository.Find(id);

// lets use the person's name
person.Name.toLower()
//Oops, `Name` could have been null and now we have a runtime exception
```

We have all had situations where this is the case, and generally we do something like:

```
if (person.Name)
	return person.Name.toLower();
else
	return "";
```

The issue is that the developer accesing the `Person` object may not be aware of the fact that `Name` can be null.

This is a huge problem. In the world of strictly typed languages, we want to leverage the type system to tell us when we are doing something wrong. We shouldn't assume the caller, or consumer of the code, implicitly knows that the `Name` could be null. Rather we want the type system to 'communicate' to the consumer that they need to handle the fact that `Name` can and will be null in some circumstances.

This may force the consumer of the code to do more work, but it also prevents exceptions at runtime (especially in dynamic languages, like JS).

When we force the developer to expect the unexpected, like with nulls, they end up having to put in place a lot of defensive code, like `if` checks. But when we force the developer to acknoledge they type system, they will build it in from the start. 

So how do we force the consumer to acknowledge that a null may occur?

With Maybe!

```
type Person = {
	Name: Maybe<string>
}
```

First, we implement `Maybe` into our Person type, so when its used, it forces the developer to realize it maybe empty:

```
var person = new Person();

va name = person.Name.match(
	Some: name => name.toLower(),
	None: () => ""
)
```

`match` is a simple function that 





Here's the implementation:

```
var str = "George"
type Person = {
	Name: Maybe<string>
}

var some = Some(str);

var none = None();

var obj = new Person() {
	Name: some
}
```

So either the person's name can either be 'Some', where we have their name. Or 'None' where we don't actually have their name.

Because the type system knows that the `Name` may be empty or None, it forces us to take it into account.

This is in direct oposition to the use of `null`. With null we may accidentally try and use a value that is empty or null.

```
var person = new Person();

person.Name.toLower();
```

Now, when we try and use `Name` it is going to throw an error because it may possibly be null, and you cannot call `toLower()` on a null value.

To make the above code defensive, you'd have to do something like this:

```
var person = new Person();

if (person.Name)
	return person.Name.toLower();
else
	return "";
```

The issue is that the developer accesing the `Person` object may not be aware of the fact that `Name` can be null.

This is a huge problem. In the world of strictly typed languages, we want to leverage the type system to tell us when we are doing something wrong. We shouldn't assume the 'client', or consumer of the code, implicitly knows that the `Name` could be null. Rather we want the type system to 'communicate' to the consumer that they need to handle the fact that `Name` can and will be null in some circumstances.

Though this puts more work onto the consumer of the code, it also prevents exceptions at runtime (especially in dynamic languages, like JS).

When we force the developer to expect the unexpected, like with nulls, they end up having to put in place a lot of defensive code, like `if` checks. But when we force the developer to acknoledge they type system, they will build it in from the start. 

The resulting code may look something more like this:

```
var person = new Person();

va name = person.Name.match(
	Some: name => name.toLower(),
	None: () => ""
)
```

At first, this may look like a hurdle to overcome, once you start using it, it forces the consumer to handle all cases directly in the code. This prevents a significant amount of runtime errors and bugs.

## Lets understand Maybe a bit further

Lets look at the `List` implementaton in C# since its strongly typed:

```
var list = List<string>() { "ABC" };

list.Select(str => str.ToLower())
```

The `Select` function will work the same way the `map` function works in JavaScript.

The function will 'apply' the `ToLower()' function to each string in its list. So "ABC" will turn into "abc".

We can use `map` in the same way against a Maybe.

Think of `Maybe` as a `List` that can either contain zero or one item.

```
var list1 = Maybe<string>() { "ABC" }; //This isnt really valid, but illustrates a point
list1.Select(str => str.ToLower()) // Some("abc")

var list2 = Maybe<string>() {};
list2.Select(str => str.ToLower()) // None()
```

The key think to notice here is that neither `Select` nor `ToLower` throw an exception because there is an empty value.

This is very important. `Maybe` provides a 'structure' to pass around, that will not cause exceptions.

If we just passed around the `String` structure, and called `ToLower`, errors would be thrown. But because we have an encapsulating structure `Maybe`, if the value is nothing, we can immediatley return `None` **without even running the `ToLower` function. Performance, Yea Baby Yea!




## Maybe - Just a List with an item or empty

Once we realize that structures like Maybe exist, we'll start seeing them all over the place. When `null` is potentially returned, lets return a `Maybe` instead:

Traditionally we'd do something like this:

```
let person = _personRepository.Find(id);

if (person == null)
	throw new Error(`Person with id ${id} does not exist`);
else
	return person.Name;
```

But then you need to figure out how to handle the error. 

Instead, lets try:

```
let maybePerson = _personRepository.Find(id);

return maybePerson(
	Some: person => person.Name,
	None: ""
)
```









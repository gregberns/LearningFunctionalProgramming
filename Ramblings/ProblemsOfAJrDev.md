# Problems of a Junior Developer

When I started programming, just getting something to work was a miracle, but as I gained experience, it became very evident that the way code was organized became more and more critical. Generally I'd write a bunch of code, and it worked. Then I tried to implement a new feature and BOOM, it hit me. There was no way I could write the feature without a major change to the code. 

This continued for a long time and happen over and over. I'd write some code, then realize how poorly structured it was. I'd want to add one feature and all (or most) the code had to change. 

This frustrated me to no end. It seemed like such a waste of time writing and rewriting code over and over and over. And over. And over again.

From what I can tell, there is no silver bullet to fix this problem, but there are some simple ideas that can help reduce the need for major refactors and also help with code readability.

* DDD - Domain Driven Development
* validateing ALL data before it comes into the domain

## What is Domain Driven Development

At its core, Domain Driven Development, is a simple concept: make you code look like the problem you are trying to solve.

So if you have a `Person` in the real world, and that Person has a First and Last name, then create a Person object that has a First and Last name.

Simple! Right?

In fact it is that simple. When trying to solve a problem, if we model the 'domain', or the problem we are trying to solve, exactly like it is in the real world, then our program will 'look' exactly like the problem.

The reason this is important is because when we need to add a new feature, like adding a BirthDate, our application already closely mirrors the real world, and we just need to add the 


## Validating Data

Before the data enters the domain, we want to make sure it is correct as possible. We want to do this so when the data is in the domain, we don't need to do additional validation.

So if we expect a Person to have a BirthDate, not only can we be assured the person has a BirthDate, but it is valid. 

Before we allow a Person to be created then, we need to do a little validation:

```
Person CreatePerson(string firstName, string lastName, DateTime birthDate) {
	//If the person is over 120 years old, throw an error
	if (DateTime.Now.Year - birthDate.Year > 120) {
		throw new Exception("Person cannot be more than 120 years old");
	}
}
```


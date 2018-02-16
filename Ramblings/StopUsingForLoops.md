# Stop Writing For/For Each Loops

For loops are one of the most powerful programming concepts.
They allow you to iterate over a set of values. This may be one of the most common things we do as programmers.

---

And I'm asking you to stop.

I'm not asking you to stop over a set of values, just with `for` or `for each`.

---

Why to get rid of ForLoops?

Because...

They are too powerful!

----

Why would we want to get rid of that?

Because programming is full of tradeoffs. With more power comes more responsibility.

With more responsibility, comes more potential for abuse.

```csharp
for (var i = 1; i > 100; i++) {
	if (i % 15) {
		console.log(“FizzBuzz”);
	} else if (i % 3) {
		console.log(“Fizz”);
	} else if (i % 5) {
		console.log(“Buzz”);
	} else {
		console.log(i);
	}
}
```

---

The power of `for` loops turns into a liability not a benefit very easily.

???

Show how the structure of a foreach has so much flexibility, which is a problem when it comes to readability. 

Have a person read code theyve never seen before. They talk through everything they see and their process of trying to understand that new code. Show how map, filter, and fold make it easier to read. Which makes it easier to understand.

---

What are the problems with this code:

- Cant unit test it - the inner code you can’t validate
- Cant test the output - how do you validate the 
- Cant change the output - change from Console to something else, or to send to two places
- Not modular - cant reuse the embedded logic
- Cant change the looping mechanism

Changes:
- Change the ‘end’ number
- Make it go forever
- Translate it to another language
- Make it iterate through the Fibbonoci

---

We start with a simple for loop:

```
	var list = List<string>() { “1”, “2”, 3” };
	var newList = new List<int>();
	foreach (var i in list) {
		newList.Add(int.Parse(i));
	}
	return newList;
```

---

Then we realize we have to modify it, because we didn’t really think it through:

```
	var list = List<string>() { “1”, “2”, 3” };
	var newList = new List<int>();
	foreach (var i in list) {
		int parsedInt;
		bool isInt = int.TryParse(i, out parsedInt);
		newList.Add(parsedInt);
	}
	return newList;
```

---

Ooops… forgot the `if` check, because the compiler didn’t warn us

```
	var list = List<string>() { “1”, “2”, 3” };
	var newList = new List<int>();
	foreach (var i in list) {
		int parsedInt;
		bool isInt = int.TryParse(i, out parsedInt);
		if (isInt)
			newList.Add(parsedInt);
		else
			//not really sure what to do here??
	}
	return newList;
```

---

A couple iterations later

```
	var list = List<string>() { “1”, “2”, 3” };
	var newList = new List<int>();
	var total = 0;
	foreach (var i in list) {
		if (i == null) continue;
		i = i.Trim();
		int parsedInt;
		bool isInt = int.TryParse(i, out parsedInt);
		if (isInt) {
			parsedInt = parsedInt + 1;
			total = total + parsedInt;
			newList.Add(parsedInt);
		}
		else
		//still not sure what to do here...
	}
	return newList;
```

---

Where we could have just done:

```
	var newList = list.Filter(s => !string.IsNullOrEmpty(s))
						.Select(s => s.Trim))
						.Select(s => ParseInt(s))
						.Filter(e => e.IsRight)  //Meaning it is a valid int
						.Select(i => i + 1);
						.Aggregate(0, (a,i) => a+i)
```

Its much cleaner, easier to read and extend.

In JavaScript you can use `map`, `filter`, and `fold`(Aggregate) for these types of operations.
JavaScript Promises can also contain multiple data transforms.

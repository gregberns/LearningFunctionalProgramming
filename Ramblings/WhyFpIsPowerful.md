# Why Functional Programming is Powerful

Why I like Functional Programing Principles

![Garbage Code](https://xkcd.com/1513/)

---

I have written so much bad code… SO MUCH!!!

5k Java - Garbage - un-testable
5k .NET - Garbage - barely testable, uncomprehensible, now re-written
?k .NET - OK - SQL to Objects - unused by users
Unknown Node - trashed - business didnt work
Unknown .NET - trashed - business didnt work

---

I believe its important to be forthright in the crap I have written.

This is my atonement.

Its a waste to the business, me, and my customers.

Don't be proud. But be realistic.

This code provided value.

---

What are my issues:

- Exposing methods to mutate internal data but then not knowing which method needed to come first
- Mutation(changing) of objects that caused other methods to fail
- Didnt dependency inject(didnt know what dependancy injection was until 4 years into my career), 
- Confusing classes that were a nightmare to maintain,  
- Sat in the debugger all day trying to get a string 10 levels deep to format correctly
- Didnt know how unit testing was possible (it wasn’t cause my code was such shit), 
- Contributory Negligence - allowing 1000 line methods to get even larger

Deleting customer data and wasting hours of their time because I didn’t know there was a difference between:

```
var a = “abc”
if (a.equals(“abc”))
if (a == “abc”)
```

---

I am not an advocate because I’m a FP religious zelot but because:
- It makes me feel like a less shitty developer
- In the last year I’ve been able to sleep at night because I don’t feel so bad about myself.
- I don’t feel terrible for developing such garbage, wasting so many hours re-writing and fixing terrible, horrible garbage. 
- Wasting mine, customers, and others time on stupid code mistakes. 
- I’ve stopped rearranging the chairs on my Titanic of buggy, crappy code.

That’s why I like many of the functional programming principles. I can now sleep at night. My code works.

Maybe some of these concepts can help you too.

![If there were no bugs in the code, I'd be so happy](https://s-media-cache-ak0.pinimg.com/originals/55/33/4a/55334a7282fb11d922c32e11c044b31a.jpg)

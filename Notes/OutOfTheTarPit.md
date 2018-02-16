Out of the Tar Pit

http://curtclifton.net/papers/MoseleyMarks06a.pdf



## State

> If the procedure in question (which is itself stateless) makes use of any other procedure which is stateful — even indirectly — then all bets are off, our procedure becomes contaminated and we can only understand it in the context of state.

> As a result of all the above reasons it is our belief that the single biggest remaining cause of complexity in most contemporary large systems is state, and the more we can do to limit and manage state, the better.



Initialize View
Fetch values from services
Set values to internal properties
In the View, access combine properties to determine how rendering is done



## Complexity by Control

This is complexity through order of operations. If operations require a specific order, they 

> When a programmer is forced (through use of a language with implicit control flow) to specify the control, he or she is being forced to specify an aspect of how the system should work rather than simply what is desired.



Specifying the 'how':
* Prevents optimization by the system/compiler
* The 'how' will require code to be written. The more code the more bugs.
* 

Contrast SQL with C. SQL in most cases does not tie execution to the order o and so can be highly optimized by the 

Improve Through Declaritive vs Imeritive.

Order is incredibly important. 

Change

```
var _a = a + b
var _b = b + c
var o = new Object();
o.a = _a
o.b = _b
return o
```

```
return {
	a: a + b
	b: b + c
}
```



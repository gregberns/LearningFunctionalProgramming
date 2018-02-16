

Math symbols

￢ - NOT
⋀ - AND
⋁ - OR 
=> - implies - LHS must be true for the right habd side to be true
= - equals

⨁
⨂



http://blg89.net/blog/wp-content/uploads/2013/11/The-Science-Of-Programming-Gries-038790641X.pdf


{ 0 <= x && 0 < y } //Assert
var r = x
var q = 0
{ 0 <= x && 0 < y && x = y*q + r }
while (r > y)
	r = r - y
	q = q + 1
{ 0 <= r < y && x = y*q + r } //Assert


Lets pull this into more generic description

{ Q }
S
{ R }

`{ Q }` is the 'precondition', or an assertion check to ensure all conditions are met. 
Command `S` changes S so that R is true
`{ R }` is the 'postcondition', which asserts the state now meets some conditions

Lets make this practical now.

If we validate everything (Q) coming into a function (S), we have better guarentees our function will not crash or fail due to invalid inputs. If we also validate the output (R) it helps us ensure that function is working and you wont break anything eldse


	dividend
var divisor



Page 111

Commands can be either deterministic or non-deterministic

So if you use ⋀ (and) notice the equality between the LHS and RHS

wp(S, Q) ⋀ wp(S, R) = wp(S, Q ⋀ R)

This is deterministic, meaning there is a known response.

But if you use ⋁ (or) notice the LHS implies the RHS, or 

wp(S, Q) ⋁ wp(S, R) => wp(S, Q ⋁ R)

This is because S can be non-deterministic.

Execution of a statement is non-deterministic if it need not always be exactly the same each time it is begun in the same state. It may produce different answers.

`SELECT * FROM table` is non-deterministic because it may return 0, 1 or n records.



Heard you on legacycoderocks and @dotnetrocks. Stolen idea: OOP creates complex machines, hard to test. Combining 'machines' are even harder to test.

OOP creates complex hard to test machines. Combining 'machines' increases complexity. FP = simple powerful reusable tools minim complxity


@Bizmonger OOP class is complex hard to test machine. Combining 'machines' increases complxty. FP = simple reusable tools w/ min complxity
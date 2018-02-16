# Think Before You Program

Though not always true, often it is not a blog article that provides great value but rather the papers and ideas it references. I found this to be true after reading Alistair Cockburn's ["Thinking Before Programming"](http://alistair.cockburn.us/Thinking+before+programming) article.

The Diamond Kata was an interesting problem and the Dijkstra-Gries method does have some great advantages to it, but in one of his 'Postscripts' he mentions:

> Their method is not at all about splitting up a program into constituent, communicating parts, something that is a much larger problem for most people on most projects these days.

Saying that though 'yes we should think about our problems more before we start writing code.' but
most of the code we end up writing is larger than one small problem and we need ways for the parts to communicate.

> In the mid-1990s, there was a minor movement called “Design from the client’s perspective”. It called for programmers to feel what is was like to be the client code calling upon a service; in fact, to write the client code first, exactly in order to feel that.

This was very interesting because I just had written a couple small (1k line) programs where I had done something very similar.

Instead of writing a 'service' that 





He then mentions [a paper by David Lorge Parnas](https://www.cs.umd.edu/class/spring2003/cmsc838p/Design/criteria.pdf) on modularization that 

> David Lorge Parnas’ work on encapsulating decisions[1], and Ward Cunningham & Kent Beck’s CRC cards, and Rebecca Wirfs-Brock’s Responsibility-Driven Design (the latter two really building on Parnas’ concept and making it super practical) address that important question.

[1] https://www.cs.umd.edu/class/spring2003/cmsc838p/Design/criteria.pdf


n % 15 === 0 ? 'fizzbuzz'
: n % 3 === 0 ? 'fizz'
: n % 5 === 0 ? 'buzz'
: n.toString()

let expressionParser = (between (char '(') (char ')') binaryExpressionParser) Text.Parsec.<|> (TTerminal <$> numberParser); binaryExpressionParser = TNode <$> expressionParser <*> operatorParser <*> expressionParser

let evaluate (TNode exp1 TAdd exp2)      = (evaluate exp1) + (evaluate exp2); evaluate (TNode exp1 TSubtract exp2) = (evaluate exp1) - (evaluate exp2); evaluate (TTerminal v)               = v

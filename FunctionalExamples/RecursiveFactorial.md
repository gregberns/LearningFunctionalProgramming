# Standard Imperative Examples Done Functionally

Some examples of how to take a simple problem that is generally done imparatively and do it in a functional way.

### Factorial problem with a Monad

Generally the factorial problem is done recursively.

```
function factorial(i) {
  if (i === 1) {
    return 1
  }
  return factorial(i - 1) * i
}
```

The problem with this approach at least is that it is not tail-call optimized and so will have call stack issues.

This example is using tail-recursion. ES6 is supposed to support this but doesn't (as of Jul 2016) so the same issue will occur. 
(Note: It does have more variables at play, maybe there's a way to reduce them...)

```
function call(n) {
  return loop(1, 1, n)
}

function loop(i, current, end) {
  console.log(`${i}, ${current}, ${end}`)
  if (current === end) {
    return i * current;
  }
  return loop(i * current, current + 1, end);
}
```

Or a better way thanks to 'You dont know JS'
https://github.com/getify/You-Dont-Know-JS/blob/master/async%20%26%20performance/ch6.md#tail-call-optimization-tco

```
function factorial(n) {
    function fact(n,res) {
        if (n < 2) return res;

        return fact( n - 1, n * res );
    }

    return fact( n, 1 );
}

factorial( 5 );     // 120
```

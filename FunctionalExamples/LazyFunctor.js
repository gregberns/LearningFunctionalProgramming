//Lazy evaluation implementation of map/filter
//Based on this article
//https://dev.to/nestedsoftware/lazy-evaluation-in-javascript-with-generators-map-filter-and-reduce--36h5

//http://jsbin.com/nexafew/edit?js,console

const Lazy = (gen, f) => ({
  map: g => Lazy(gen, x => g(f(x))),
  take: (n) => {
    let values = [];
    for (let i=0; i<n; i++) {
      let val = gen.next().value
      let ret = f(val)
      values.push(ret)
    }
    return values;
  },
  takeWhile: (e, p) => {
    let ret = e;
    let next = () => gen.next().value
    while (true) {
      let val = f(next())
      if (!p(val)) {
        break 
      }
      ret = [...ret, val]
    }
    return ret;
  }
})

const identity = x => x

Lazy.new = gen => Lazy(gen, identity)
Lazy.empty = () => []

const numbers = function* () {
    let i = 1
    while (true) {
        yield i++ 
    }
}

const e = 
  Lazy.new(numbers())
    .map(x => x * 3)
    .take(5)

console.log(e)

const f = 
  Lazy.new(numbers())
    .map(x => x * 3)
    .reduce(Lazy.empty(), x => i % 2 === 0)
    .takeWhile(x => x < 10)

console.log(f)

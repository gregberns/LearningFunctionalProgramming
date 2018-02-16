// This is an example of how to do a factorial with a monad

function createMonad(i) {
  let n = {
     a: 1,
     current: 1,
     end: i
  }
  let m = {
    value:() => n.a,
    current: () => n.current,
    end: () => n.end,
    next: function () {
      n.a = n.a * n.current
      n.current = n.current + 1
      n.end = n.end
      return m
    }
  }
  return m
}

let m = createMonad(99)
while (m.current() <= m.end()) { 
  m = m.next();
  console.log(m)
}

console.log(m.value())

// Iteration #2

function createMonad(i) {
  let n = {
    end: i,
    current: 1,
    value: 1
  };
  let m = {
    get done () {
      return n.end < n.current
    },
    get value () {
      return n.value
    },
    next: function () {
      n.value = n.value * n.current
      n.current = n.current + 1
      return m
    }
  }
  return m
}

let m = createMonad(5)
while (!m.done) { 
  m = m.next();
  console.log(m)
}

console.log(m.value)

// Iteration #3 - Ability to iterate over the monad

function createMonad(i) {
  let n = {
    end: i,
    current: 1,
    value: 1
  };
  let m = {
    get done () {
      return n.end < n.current
    },
    get value () {
      return n.value
    },
    next: function () {
      n.value = n.value * n.current
      n.current = n.current + 1
      return m
    }
  }
  m[Symbol.iterator] = m.next
  return m
}

let m = createMonad(5)

for (var i of m) {
  console.log(i);
}

console.log(m.value)

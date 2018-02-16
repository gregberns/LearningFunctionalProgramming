/**
 * It is possible to build all computation out of 
 * only lambda expressions. Everything is as a lambda!!
 * 
 * Programming with Nothing by Tom Stuart
 * https://www.youtube.com/watch?v=VUhlNx_-wYk
 */

let ZERO = p => x => x
let ONE = p => x => p(x)
let TWO = p => x => p(p(x))
let THREE = p => x => p(p(p(x)))

let TRUE = x => y => x
let FALSE = x => y => y
let IF = b => x => y => b(x)(y)
let IS_ZERO = n => n(x => FALSE)(TRUE)

let TO_INT = p => p(x => x + 1)(0)
let EQ = x => y => x === y ? TRUE : FALSE

let LIST = x => y => f => f(x)(y)
let LEFT = p => p(x => y => x)
let RIGHT = p => p(x => y => y)



//console.log(TO_INT(TWO))


console.log(RIGHT(LIST(ONE)(TWO)))

//console.log(IS_ZERO(TWO))

// console.log(
//   IF(EQ(ONE)(TWO))
//     (ONE)
//   (IF(IS_ZERO(ZERO))
//     (3)
//     (4)
//   )
// )

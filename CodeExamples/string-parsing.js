#!/usr/bin/env node
const fetch = require('node-fetch');
const Async = require('crocks/Async');
const Maybe = require('crocks/Maybe');
const Either = require('crocks/Either');
const Helpers = require('crocks/Helpers');

const { Rejected, Resolved } = Async;
const { Just, Nothing } = Maybe;
const { Left, Right } = Either;
const { pipe, liftA2 } = Helpers;


// This is a code excercise to show how 
// using function composition can be not
// only more robust, but more reusable,
// reliable, and testable.




// What are pure functions? 
// What can they look like in JS?



//Pure Functions
function pureA(a) {  //Identity
  return a;
}




const pureB = a => {  //Constant
  return 1;
}




const pureC = a => b => a + b





const impureA = a => {
  console.log(a)
  return a;
}



const impureB = url => {
  return fetch(url);
}











//get the count of 'words' in this string 
//  (the letters represent the 'words')
let st = "a b c\nd e f\ng h i"


// Problem: write code to parse the string above and
// return the count of 'words' (in this case just letters)

//Simple solution:

st.replace('\n', ' ').split(' ').length

//What problems can arise from using this code?

var a = s.split('\n')
a.split()



const line = s => s.split('\n')

const word = s => s.split(' ')

const lift = a => a.reduce((acc, v) => [...acc, ...v ] , [] )

const map = f => a => a.map(f)

const length = arr => arr.length

console.log(lift(line(st).map(word)).length)

let a = pipe(
  line,
  map(word),
  lift,
  length
)(st)

console.log(a)













//get the lines 
//then words
//
//lift
//count them

//let st = "a b c\nd e f\ng h i"

//console.log(st.split(' '))






























// const lines = s => s.split('\n')
// const words = s => s.split(' ')
// const map = f => a => a.map(f)
// const length = a => a.length

// console.log(lines(st).map(words))

// const pipe2 =
//   (p1, p2, v) => [v].map(p1).map(p2)[0]

// const liftArray =
//   a => a.reduce((acc, v) => [...acc, ...v], [])

// console.log(
//   pipe(
//     lines, 
//     map(words),
//     liftArray,
//     length)
//     (st)
// )

// console.log(
//   pipe2(
//     lines, 
//     map(words),
//     st)
// )


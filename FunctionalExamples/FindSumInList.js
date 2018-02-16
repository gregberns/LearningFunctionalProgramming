/*
# Find Sum In List

*Problem*

Given a list of sorted integers and a 'sum' value, attempt to find two numbers in the list that when summed equal the 'sum' value. 

Example 1:

[1,2,3,9], sum:8
Result: None

Example 2:

[1,2,4,4], sum:8
Result: (4,4)

*/
function run(value) {
	return function checkList(l) {
        console.log(l)
		if (l.count <= 1) return {}
		let i = first(l)
		let j = last(l)
		let s = i+j
		if (s < value) {
            console.log('less')
			return checkList(removeFirst(l))
		} else if (value < s) {
			console.log('more')
            return checkList(removeLast(l))
		} else if (value == s) {
            return {i,j}
        }
        console.log(`${i} ${j} ${l}`)
	}
}
function first(l) {
	return R.head(l)
}
function last(l) {
	return R.last(l)
}
function removeFirst(l) {
	return R.drop(1, l)
}
function removeLast(l) {
	return R.dropLast(1, l)
}

//Tests
var a = [1,2,4,4]
console.log(first(a))
console.log(last(a))
console.log(removeFirst(a))
console.log(removeLast(a))

//Examples
console.log(run(8)([1,2,4,4]))

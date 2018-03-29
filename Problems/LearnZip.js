// Challenge: 
//   Use zip and reduceWhile to improve this code snippet
// http://ramdajs.com/docs/#reduceWhile
// http://ramdajs.com/docs/#zip

function compareSemanticVersions(a: string, b: string): number {
  if (a === b) {
    return 0;
  }

  let aVersions =  a.split('.');
  let bVersions = b.split('.');
  let maxVersionLength = Math.max(aVersions.length, bVersions.length);

  // pad arrays to the max length of the version strings being compared
  aVersions.fill('0', aVersions.length, maxVersionLength);
  bVersions.fill('0', bVersions.length, maxVersionLength);

  return Array.from(Array(maxVersionLength).keys())
    .reduce((prevEql, i) => {
      return prevEql !== 0
        ? prevEql
        : aVersions[i].localeCompare(bVersions[i]);
    }, 0);
}

const AssertEqual = (a, b, message) => {
  if (a !== b) throw new Error(message)
}
AssertEqual(compareSemanticVersions('1.0.0', '1.0.0'), 0, 'Versions are equal')
AssertEqual(compareSemanticVersions('1.0.1', '1.0.0'), 1, 'Version A is greater')
AssertEqual(compareSemanticVersions('1.0.1', '1.0.1'), -1, 'Version B is greater')
console.log('Looks Good!')

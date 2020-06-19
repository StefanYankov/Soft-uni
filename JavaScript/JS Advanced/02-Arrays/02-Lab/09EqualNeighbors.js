// with for loops
const matrix = [
  ['2', '3', '4', '7', '0'],
  ['4', '0', '5', '3', '4'],
  ['2', '8', '1', '4', '2'],
  ['9', '8', '7', '5', '4']
];

const stringMatrix = [
  ['test', 'yes', 'yo', 'ho'],
  ['well', 'done', 'yo', '6'],
  ['not', 'done', 'yet', '5']
];

const thirdMatrix = [
  [2, 2, 5, 7, 4],
  [4, 0, 5, 3, 4],
  [2, 5, 5, 4, 2],
];
function getNeightboursCount(inputMatrix) {

  let count = 0
  for (let i = 0; i < inputMatrix.length; i++) {

      const currentElement = inputMatrix[i];
      const nextElement = inputMatrix[i + 1];

      for (let j = 0; j < currentElement.length; j++) {

          let firstElement = currentElement[j];

          
          if (j < currentElement.length - 1) {
              let secondElement = currentElement[j + 1];
              if (firstElement === secondElement) {
                  count++;
              }
          }

          if(i < inputMatrix.length - 1) {
              let firstElementNextRow = nextElement[j];
              if (firstElement === firstElementNextRow) {
                  count++;
              }
          }
      }
  }
  return count;
}
console.log(getNeightboursCount(thirdMatrix));


// with reduce
function equalNeighbors(input2DArray) {
  const result = input2DArray.reduce((acc, currRow, rowIndex) => {
    const currCount = currRow.reduce((acc, currValue, currIndex) => {
      if (currValue === currRow[currIndex + 1]) {
        acc += 1;
      }

      if (currValue === (input2DArray[rowIndex + 1] || [])[currIndex]) {
        acc += 1;
      }

      return acc;
    }, 0);

    return currCount + acc;
  }, 0);

  return result;
}

equalNeighbors([
  ["2", "3", "4", "7", "0"],
  ["4", "0", "5", "3", "4"],
  ["2", "3", "5", "4", "2"],
  ["9", "8", "7", "5", "4"],
]);

console.log(
  findEqualNeighbours([
    ["test", "yes", "yo", "ho"],
    ["well", "done", "yo", "6"],
    ["not", "done", "yet", "5"],
  ])
);

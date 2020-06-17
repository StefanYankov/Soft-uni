function diagonalSums(input2DArray) {
  let mainDiagonalSum = 0;
  let secondariDiagonalSum = 0;

  for (let i = 0; i < input2DArray.length; i++) {
    let tempElement = input2DArray[i];

    for (let j = 0; j < tempElement.length; j++) {
      if (i === j) {
        mainDiagonalSum += input2DArray[i][j];
      } 
      
      if (i + j === input2DArray.length - 1) {
        secondariDiagonalSum += input2DArray[i][j];
      }
    }
  }
  console.log(mainDiagonalSum + " " + secondariDiagonalSum);
}

//diagonalSums([[20, 40], [10, 60]]);
diagonalSums([[3, 5, 17], [-1, 7, 14], [1, -8, 89]]);

function biggestElement(input2DArray){

    let tempMax = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < input2DArray.length; i++) {
        let tempElement = input2DArray[i];
        for (let j = 0; j < tempElement.length; j++) {

            if(input2DArray[i][j] > tempMax){
                tempMax = input2DArray[i][j];
            }
            
        }
        
    }
    console.log(tempMax);
}

/*
function biggestElement(input2DArray) {
    const flattenedMatrix = input2DArray.flat();
    const biggestNumber = flattenedMatrix.reduce((acc, curr) => Math.max(acc, curr));

    return biggestNumber;
}
*/

biggestElement([[20, 50, 10], [8, 33, 145]]);
biggestElement([[3, 5, 7, 12], [-1, 4, 33, 2], [8, 3, 0, 4]]);
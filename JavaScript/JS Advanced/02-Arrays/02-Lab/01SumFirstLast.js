function sumFirstLast(inputArray){

    let sum = 0;
    let lastElementIndex = inputArray.length -1;
    let firstElement = Number(inputArray[0]);
    let lastElement = Number(inputArray[lastElementIndex]);
    sum = firstElement + lastElement;

    return sum;
}

console.log(sumFirstLast(['20', '30', '40']));
function printArrayWithGivenDelimiter(inputArray) {
    const tempArray = inputArray;
    let delimiter = tempArray.pop();

    console.log(tempArray.join(delimiter));
}


const input = ['One', 'Two', 'Three', 'Four', 'Five', '-'];

printArrayWithGivenDelimiter(input);
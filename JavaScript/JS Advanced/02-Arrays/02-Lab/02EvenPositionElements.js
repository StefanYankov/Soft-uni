function evenPositionsElements(inputArray){

    const tempArray = [];

    for (let index = 0; index < inputArray.length; index+= 2) {

        tempArray.push(inputArray[index]);
    }

    return tempArray.join(' ');
}

console.log(evenPositionsElements(['20', '30', '40']));

console.log(evenPositionsElements(['5', '10']));
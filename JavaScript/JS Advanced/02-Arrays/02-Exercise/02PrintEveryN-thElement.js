function printEveryNthElement(inputArray) {

    const tempArray = inputArray;
    let step = Number(tempArray.pop());

    for (let i = 0; i < tempArray.length; i+= step) {
        console.log(tempArray[i]);
    }

}

const inputArray = ['5','20','31','4','20','2'];
const inputArray2 = ['dsa',
'asd', 
'test', 
'tset', 
'2']
;
printEveryNthElement(inputArray);
printEveryNthElement(inputArray2);
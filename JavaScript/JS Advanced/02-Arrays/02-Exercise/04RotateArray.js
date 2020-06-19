function rotateArray(inputArray = []) {

    const tempArray = inputArray;
    let rotations = Number(tempArray.pop());
    let newRotations = 0;
    if(rotations < tempArray.size){
        newRotations = rotations;
    } else {
        let temp = rotations / tempArray.size;
        newRotations = rotations - temp * tempArray.size;
    }


    for (let i = 1; i <= newRotations; i++) {
        let tempElement = tempArray.pop();
        tempArray.unshift(tempElement);
    }

    console.log(tempArray.join(' '));
}

const input = ['1','2','3','4','2'];
const input2 = ['Banana', 'Orange', 'Coconut', 'Apple', '15'];

rotateArray(input);
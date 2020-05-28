function calorieObjects(inputArray){

    let outputObject = {};

    for (let i = 0; i < inputArray.length; i+= 2){

        outputObject[inputArray[i]] = parseInt(inputArray[i+1]);
    }
    return outputObject;
}
calorieObjects(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
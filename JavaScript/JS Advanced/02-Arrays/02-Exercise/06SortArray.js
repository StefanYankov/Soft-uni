function sortArray(inputArray){

    const outputArray = inputArray
    .sort((firstName, secondName) => firstName.length - secondName.length || firstName.localeCompare(secondName));

    console.log(outputArray.join('\n'));
}

const input = ['alpha', 'beta', 'gamma'];
const input2 = ['Isacc', 'Theodor', 'Jack', 'Harrison', 'George'];
const input3 = ['test', 'Deny', 'omen', 'Default'];

sortArray(input);
console.log("===================");
sortArray(input2);
console.log("===================");
sortArray(input3);


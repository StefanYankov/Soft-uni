function smallestTwoNumbers(inputArray){

    function compareNumbers(a,b) {
        return a - b;
    }
    inputArray.sort(compareNumbers);
    const outputArray = inputArray.slice(0, 2);
    console.log(outputArray.join(' '));
}

smallestTwoNumbers([30, 15, 50, 5])
smallestTwoNumbers([3, 0, 10, 4, 7, 3])
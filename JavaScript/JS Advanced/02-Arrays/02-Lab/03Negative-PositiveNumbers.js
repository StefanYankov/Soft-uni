function negativePositiveNumbers(inputArray){

    const tempArray = inputArray.sort(function (a,b){return a - b});

    tempArray.forEach(element => { console.log(element);
        
    });
}

negativePositiveNumbers([7, -2, 8, 9]);
console.log();
negativePositiveNumbers([3, -2, 0, -1]);
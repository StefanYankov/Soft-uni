function greatestCommonDivisor(inputFirstNumber, inputSecondNumber){

    if((typeof inputFirstNumber !== 'number') || (typeof inputSecondNumber !== 'number')){
        console.log("Input needs to be two numbers.");
        return false;
    }

    let firstNumber = Math.abs(inputFirstNumber);
    let secondNumber = Math.abs(inputSecondNumber);

    while(secondNumber !== 0){
        let tempNumber = secondNumber;
        secondNumber = firstNumber % secondNumber;
        firstNumber = tempNumber;
    }

    console.log(firstNumber);
}

greatestCommonDivisor('9,3', 'pesho');
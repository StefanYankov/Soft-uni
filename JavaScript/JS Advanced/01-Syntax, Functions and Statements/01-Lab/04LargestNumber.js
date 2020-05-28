function largestNumber(inputFirstNumber, inputSecondNumber, inputThirdNumber){
    let firstNumber = inputFirstNumber;
    let secondNumber = inputSecondNumber;
    let thirdNumber = inputThirdNumber;

    let maxNumber = firstNumber;

    if(secondNumber > maxNumber){
        maxNumber = secondNumber;
    }
    
    if(thirdNumber > maxNumber) {
        maxNumber = thirdNumber;
    }
    console.log(`The largest number is ${maxNumber}.`);
}

largestNumber(12,12,11);
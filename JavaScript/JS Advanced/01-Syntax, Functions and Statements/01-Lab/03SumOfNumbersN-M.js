function sumOfTwoNumbers(firstNumber, secondNumber){
    let num1 = +firstNumber;
    let num2 = +secondNumber;
    let result = 0;
    for(let i = num1; i <= num2; i++) {
        result += i;
    }
    return result;
}

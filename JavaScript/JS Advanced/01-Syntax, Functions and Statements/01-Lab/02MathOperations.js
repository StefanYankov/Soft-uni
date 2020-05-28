function solver(firstNumber, secondNumber, operator) {
    let result;
    switch (operator) {
        case '+' : result = firstNumber + secondNumber;
        break;
        case '-' : result = firstNumber - secondNumber;
        break;
        case '*' : result = firstNumber * secondNumber;
        break;
        case '/' :
            if(secondNumber == 0) {
                console.log("Illegal operationr -> you can't divide by zero");
                return;
            }
            result = firstNumber / secondNumber;
            break;
        case '%': 
        if(secondNumber == 0) {
            console.log("Illegal operationr -> you can't divide by zero");
            return;
        }
        result = firstNumber % secondNumber ;
        break;
        case '**' : result = firstNumber ** secondNumber;
    }
    console.log(result);
}

solver(5, 0, '/');
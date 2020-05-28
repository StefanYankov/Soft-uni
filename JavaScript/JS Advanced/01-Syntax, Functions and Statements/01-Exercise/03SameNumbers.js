function sameNumbers(inputNumber){

    let numberToString = String(inputNumber);
    let isSameDigis = true;
    let sum = Number(numberToString[0]);
    for (let i = 1; i < numberToString.length; i++){
        if(numberToString[i] !== numberToString[i-1]){
            isSameDigis = false;
        }
        sum += Number(numberToString[i]);
    }
    console.log(isSameDigis);
    console.log(sum);
}

sameNumbers(1234);
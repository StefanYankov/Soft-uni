function wordsUppercase(inputString){

    let tempStringUpperCase = inputString.toUpperCase();
    let splitString = tempStringUpperCase.split(/[\W]+/).filter(w => w.length > 0);
    let outputString = splitString.join(", ");
    console.log(outputString); 
}

wordsUppercase("Hi, how are you?");
function solve(firstArgument, secondArgument, thirdArgument){
    let totalLength;
    let averageLength;

    let firstString = firstArgument.length;
    let secondString = secondArgument.length;
    let thirdString = thirdArgument.length;

    totalLength = firstString + secondString + thirdString;
    averageLength = Math.floor(totalLength / 3);

    console.log(totalLength);
    console.log(averageLength);
      
}

solve('chocolate', 'ice cream', 'cake');
function solve(inputArray, startIndex, endIndex) {
    if (!Array.isArray(inputArray)) {
        return NaN;
    }

    for (const element of inputArray) {
        if (!(typeof (element) === 'number')) {
            return NaN;
        }
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (endIndex >= inputArray.length) {
        endIndex = inputArray.length - 1;
    }

    let output = 0;

    for (let i = startIndex; i <= endIndex; i++) {
        output += inputArray[i];
    }
    return output;
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300)); // 150
console.log("________________");
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1)) // 3.3
console.log("________________");
console.log(solve([10, 'twenty', 30, 40], 0, 2)) // NaN
console.log("________________");
console.log(solve([], 1, 2)) // 0
console.log("________________");
console.log(solve('text', 0, 2)) // NaN
console.log("________________");
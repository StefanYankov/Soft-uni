function magicMatrices(inputMatrix = []) {

    let isEqual = true;
    const firstRowSum = inputMatrix[0].reduce((a, b) => a + b, 0);

    for (let i = 0; i < inputMatrix.length; i++) {
        const rowSum = inputMatrix[i].reduce((a, b) => a + b, 0);
        const colSum = inputMatrix.map(x => x[i]).reduce((a, b) => a + b, 0);

        if (rowSum !== firstRowSum || colSum !== firstRowSum) {
            isEqual = false;
        }
    }

    console.log(isEqual);
}

const input = [
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
];

const input2 = [
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
];

const input3 = [
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
];

magicMatrices(input);
magicMatrices(input2);
magicMatrices(input3);

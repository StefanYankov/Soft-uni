function playTicTacToe(playerInput = []) {
    function printMatrix(inputMatrix = []) {
        for (let i = 0; i < inputMatrix.length; i++) {
            console.log(inputMatrix[i].join('\t'));
        }
    }

    function checkIfWinning(inputMatrix = []) {
        let hasWon = false;
        for (let i = 0; i < 3; i++) {
            if (
                (
                    inputMatrix[i][0] === 'X' &&
                    inputMatrix[i][1] === 'X' &&
                    inputMatrix[i][2] === 'X'
                ) ||
                (
                    inputMatrix[0][0] === 'X' &&
                    inputMatrix[1][1] === 'X' &&
                    inputMatrix[2][2] === 'X'
                ) ||
                (
                    inputMatrix[0][2] === 'X' &&
                    inputMatrix[1][1] === 'X' &&
                    inputMatrix[2][0] === 'X'
                )
            ) {
                hasWon = true;
                console.log("Player X wins!");
                printMatrix(inputMatrix);
                break;
            } else if (
                (
                    inputMatrix[i][0] === 'O' &&
                    inputMatrix[i][1] === 'O' &&
                    inputMatrix[i][2] === 'O'
                ) ||
                (
                    inputMatrix[0][0] === 'O' &&
                    inputMatrix[1][1] === 'O' &&
                    inputMatrix[2][2] === 'O'
                ) ||
                (
                    inputMatrix[0][2] === 'O' &&
                    inputMatrix[1][1] === 'O' &&
                    inputMatrix[2][0] === 'O'
                )
            ) {
                hasWon = true;
                console.log("Player O wins!");
                printMatrix(inputMatrix);
                break;
            }
        }
        return hasWon;
    }

    const playField = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let openFields = 9;
    let counter = 0;

    for (let i = 0; i < playerInput.length; i++) {
        let row = playerInput[i].split(' ')[0];
        let column = playerInput[i].split(' ')[1];
        if (playField[row][column] === false) {
            openFields--;
            if (counter % 2 === 0) {
                playField[row][column] = 'X';
                if (openFields === 0) {
                    console.log("The game ended! Nobody wins :(");
                    return printMatrix(playField);
                }
            }
            else {
                playField[row][column] = 'O';
                if (openFields === 0) {
                    console.log("The game ended! Nobody wins :(");
                    return printMatrix(playField);
                }
            }
            counter++;
        } else {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        if (checkIfWinning(playField)) {
            return;
        }
    }

}

const playersInput = [
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"
];

const playersInput2 = [
    "0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]

const playersInput3 = [
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]

const playerInput4 = [
    "0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
];

playTicTacToe(playerInput4);
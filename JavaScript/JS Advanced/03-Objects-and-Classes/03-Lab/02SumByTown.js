function sumByTown(inputArray = []) {

    const output = {};

    for (let i = 0; i < inputArray.length; i += 2) {

        let town = inputArray[i];
        let income = Number(inputArray[i + 1]);

        if (Object.keys(output).includes(town)) {
            output[town] += income;
        } else {
            output[town] = income;
        }
    }

    return JSON.stringify(output);
}

const input = ['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4'];
const input2 = ['Sofia', '20', 'Varna', '3', 'sofia', '5', 'varna', '4'];

sumByTown(input);
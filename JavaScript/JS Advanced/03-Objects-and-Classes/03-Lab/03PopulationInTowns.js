function populationInTowns(inputArray = []) {

    const output = {};

    for (let i = 0; i < inputArray.length; i++) {
        const tempArray = inputArray[i].split(' <-> ');

        let town = tempArray[0];
        let population = Number(tempArray[1]);

        if (Object.keys(output).includes(town)) {
            output[town] += population;
        } else {
            output[town] = population;
        }
    }
    Object.entries(output).forEach(([key, value]) => console.log(`${key} : ${value}`));
}

const input = [
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
];

const input2 = [
    'Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000'
];

populationInTowns(input);
console.log("=========================");
populationInTowns(input2);
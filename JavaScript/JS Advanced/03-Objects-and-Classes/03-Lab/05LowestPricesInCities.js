function lowestPricesInCities(inputArray = []) {

    const output = new Map();

    for (let i = 0; i < inputArray.length; i++) {
        
        const tempElement = inputArray[i].split(' | ');
        let town = tempElement[0];
        let productName = tempElement[1];
        let productPrice = Number(tempElement[2]);
        // let [town, productName, productPrice] = sentance.split(" | ");

        if(!output.has(productName)){
            output.set(productName, new Map());
        }

        output.get(productName).set(town, Number(productPrice));
    }

    for (let [key, value] of output) {
        let lowest = ([...value].reduce(function (a, b) {
            if (a[1] < b[1]) {
                return a;
            } else if (a[1] > b[1]) {
                return b;
            }
            return a;
        }));
        console.log(`${key} -> ${lowest[1]} (${lowest[0]})`);
    }
}

const input = [
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'
];

lowestPricesInCities(input)
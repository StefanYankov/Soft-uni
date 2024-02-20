function storeCatalogue(inputArray = []) {

    const catalogue = {};

    for (const item of inputArray) {
        let [product, price] = item.split(' : ');

        const letter = product[0];

        if (catalogue.hasOwnProperty(letter) === false) {
            catalogue[letter] = {};
        }

        catalogue[letter][product] = price;
    }

    const sortedKeys = Object.keys(catalogue).sort((a, b) => a.localeCompare(b));
    
    for (const key of sortedKeys) {
        console.log(key);

        const sortedProducts = Object.keys(catalogue[key]).sort((a, b) => a.localeCompare(b));
        for (const product of sortedProducts) {
            console.log(`  ${product}: ${catalogue[key][product]}`);
        }
    }
}

const input = [
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'];

const input2 = [
    'Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10'
];

storeCatalogue(input);

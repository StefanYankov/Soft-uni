function register(inputArray = []) {

    const catalogue = new Map();

    for (let i = 0; i < inputArray.length; i++) {

        let [carBrand, carModel, producedCars] = inputArray[i].split(' | ');

        producedCars = Number(producedCars);

        if(catalogue.has(carBrand) === false){
            catalogue.set(carBrand, new Map());
        }

        if(catalogue.get(carBrand).has(carModel)) {

            let tempProducedCars = catalogue.get(carBrand).get(carModel);
            tempProducedCars += producedCars;
            catalogue.get(carBrand).set(carModel,tempProducedCars);
        } else {
            catalogue.get(carBrand).set(carModel, producedCars);
        }

    }

    for (let [key, value] of catalogue) {
        console.log(`${key}`);

        for (let [carModel, producedCars] of value) {
            console.log(`###${carModel} -> ${producedCars}`);
        }
    }
}

const input = [
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
];

register(input);

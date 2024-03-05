function solve(inputArray = []) {
    const brands = new Map();

    const parsedData = inputArray.map(row => row.split(' | '))
        .map(data => ({ brand: data[0], model: data[1], producedCars: Number(data[2]) }));

    for (const car of parsedData) {
        if (!brands.has(car.brand)) {
            brands.set(car.brand, new Map());
        }

        let cars = brands.get(car.brand);
        if (!cars.has(car.model)) {
            cars.set(car.model, 0);
        }

        cars.set(car.model, cars.get(car.model) + car.producedCars);
    }

    const formattedData = Array.from(brands)
        .map(brand =>
            brand[0] + '\n' +
            Array.from(brand[1])
                .map(model => `###${model[0]} -> ${model[1]}`)
                .join('\n')
        )
        .join('\n');

    return formattedData;
}

console.log(solve(
    [
        'Audi | Q7 | 1000',
        'Audi | Q6 | 100',
        'BMW | X5 | 1000',
        'BMW | X6 | 100',
        'Citroen | C4 | 123',
        'Volga | GAZ-24 | 1000000',
        'Lada | Niva | 1000000',
        'Lada | Jigula | 1000000',
        'Citroen | C4 | 22',
        'Citroen | C5 | 10']
));
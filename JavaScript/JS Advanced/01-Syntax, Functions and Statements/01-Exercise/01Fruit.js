function fruit(inputFruit, inputGrams, inputPrice){
    let fruitType = inputFruit;
    let grams = inputGrams;
    let gramsToKilograms = grams / 1000;
    let price = inputPrice;

    let neededMoney = (gramsToKilograms * price).toFixed(2);

    console.log(`I need $${neededMoney} to buy ${gramsToKilograms.toFixed(2)} kilograms ${fruitType}.`);
}

fruit('orange', 2500, 1.80);
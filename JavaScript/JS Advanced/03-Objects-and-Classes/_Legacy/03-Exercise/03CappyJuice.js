function cappyJuice(inputArray = []) {

    const object = {};
    const bottlesOutput = {};
    
    for (const line of inputArray) {

        const currentItem = line.split(' => ');
        let fruit = currentItem[0];
        let value = Number(currentItem[1]);

        if (Object.keys(object).includes(fruit)) {
            object[fruit] += value;
        } else {
            object[fruit] = value;
        }

        let currentValue = object[fruit];
        if (currentValue >= 1000) {
            const juiceLeft = currentValue % 1000;
            const bottlesCount = (currentValue - juiceLeft) / 1000;

            !bottlesOutput.hasOwnProperty(fruit) ?
                bottlesOutput[fruit] = bottlesCount : bottlesOutput[fruit] += bottlesCount;

            object[fruit] = juiceLeft;
        }


    }
    const bottles = Object.entries(bottlesOutput);

    for (const [fruit, bottleCount] of bottles) {
        console.log(`${fruit} => ${bottleCount}`);
    }
}

    const input = [
        'Orange => 2000',
        'Peach => 1432',
        'Banana => 450',
        'Peach => 600',
        'Strawberry => 549'
    ];

    cappyJuice(input);

function heroicInventory(inputArray) {

    const output = [];

    for (let i = 0; i < inputArray.length; i++) {
        
        const currentElements = inputArray[i].split(' / ');

        const name = currentElements[0];
        const level = Number(currentElements[1]);
        let items = []
        if(currentElements[2]){
            items = currentElements[2].split(', ');
        }
       
        const tempObject = {name, level, items};

        output.push(tempObject);
    }

    console.log(JSON.stringify(output));
}

const input = [
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
];

const input2 = ['Jake / 1000 / Gauss, HolidayGrenade'];
const input3 = ['Serafim / 1000 /'];

heroicInventory(input);

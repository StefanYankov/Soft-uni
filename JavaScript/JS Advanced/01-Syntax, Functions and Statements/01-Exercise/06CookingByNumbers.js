function cookingByNumbers(params){

    let number = parseInt(params[0]);
    
    let functions = {
        chop: (x) => x/2,
        dice: (x) => Math.sqrt(x),
        spice: (x) => x + 1,
        bake: (x) => x*3,
        fillet: (x) => (0.8 * x).toFixed(1)
    }

    for (let i = 1; i < params.length; i++) {
        number = functions[params[i]](number);
        console.log(number);
    }
}

cookingByNumbers(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
console.log('\n');
cookingByNumbers(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);

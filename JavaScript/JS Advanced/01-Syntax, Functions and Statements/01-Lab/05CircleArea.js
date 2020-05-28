function circleArea(inputRadius){
let area = 0;
let inputType = typeof(inputRadius);

    if(inputType === 'number'){
        area = Math.pow(inputRadius, 2) * Math.PI;
        console.log(area.toFixed(2));
    } else {
    console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    
    }
}

circleArea('name');
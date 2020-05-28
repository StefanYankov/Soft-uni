function squareOfStars(size){
    let side = size;

    if (side === undefined) {
        side = 5;
    }
    let array = [];

    for (let i = 0; i < side; i++) {
        array.push('*');
    }
    
    for (let i = 0; i < side; i++) {
        console.log(array.join(' '));
    }
}

squareOfStars(4);
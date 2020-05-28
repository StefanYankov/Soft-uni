"use strict";
function aggregateElements(items) {
    let sum = 0;
    let inverseSum = 0;
    let concatenatedItems = '';
    for (let i = 0; i < items.length; i++){
        const currentItem = items[i];
        sum += currentItem;
        inverseSum += 1/currentItem;
        concatenatedItems += currentItem;
    }
    console.log(sum);
    console.log(inverseSum);
    console.log(concatenatedItems); 
}

aggregateElements([2, 4, 8, 16]);
function sum(arr) {
    let sum = 0;
    for (const num of arr) {
        sum += Number(sum);
    }
    return sum;
}

export { sum };
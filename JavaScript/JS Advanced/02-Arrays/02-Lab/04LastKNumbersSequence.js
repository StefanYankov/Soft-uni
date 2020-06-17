function lastKNumberSequence(n, k) {
    const outputArray = [1];

    for (let i = 1; i < n; i++) {
        const startIndex = Math.max(0, i - k);
        const currArray = outputArray.slice(startIndex, startIndex + k);

        let sumOfNumbers = 0;
        for (let j = 0; j < currArray.length; j++) {
            sumOfNumbers += Number(currArray[j]);
        }

        outputArray.push(sumOfNumbers);
    }
    console.log(outputArray.join(' '));
}

lastKNumberSequence(6, 3);
function solve(inputArray = []){

    const outputArray = inputArray.reduce((acc, currentElement) => {

        const lastElement = acc[acc.length - 1];

        if(currentElement >= lastElement ||
            lastElement === undefined){
            acc.push(currentElement);
        }

        return acc;

    }, [])

    console.log(outputArray.join('\n'));
}

const input = [1, 3, 8, 4, 10, 12, 3, 2, 24];
const input2 = [1, 2, 3,4];
const input3 = [20, 3, 2, 15,6, 1];            

solve(input);
solve(input2);
solve(input3);

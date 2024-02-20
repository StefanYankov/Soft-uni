function solve(input=[]){
    const output={}

    for (const item of input) {
    
        const [cityName, population] = item.split(' <-> ');

        if (output.hasOwnProperty(cityName) == false){
            output[cityName] = 0;
        }
        output[cityName] += Number(population);
    }
    for (const item in output) {
        console.log(item, ":", output[item]);
    }
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
)
console.log("________________")
solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
)
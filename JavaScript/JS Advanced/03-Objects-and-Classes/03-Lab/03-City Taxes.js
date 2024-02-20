function cityTaxes(name="", population=0, treasury=0){

    const cityRecord = {
        name,
        population,
        treasury,
        taxRate : 10,
        collectTaxes(){
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage){
            this.population += this.population * (percentage/100);
        },
        applyRecession(percentage){
            this.treasury -= this.treasury * (percentage/100);
        }
    };
    return cityRecord;
}

const city = 
  cityTaxes('Tortuga',
  7000,
  15000);
console.log(city);

console.log("______________________");

const city2 =
  cityTaxes('Tortuga',
  7000,
  15000);
city2.collectTaxes();
console.log(city2.treasury);
city2.applyGrowth(5);
console.log(city2.population);


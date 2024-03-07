(function () {

    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (count) {
        let tempArray = [];

        for (let i = count; i < this.length; i++) {
            const element = this[i];
            tempArray.push(element);

        }
        return tempArray;
    };

    Array.prototype.take = function (count) {
        let tempArray = [];

        for (let i = 0; i < count; i++) {
            const element = this[i];

            tempArray.push(element);

        }

        return tempArray;
    }

    Array.prototype.sum = function () {
        let sum = this.reduce((acc, curr) => {
            return acc + curr;
        }, 0)
        return sum;
    }

    Array.prototype.average = function () {
        let average = 0;

        if (this.length > 0) {
            let sum = this.reduce((acc, curr) => {
                return acc + curr;
            }, 0)

            average = sum / this.length;
        }

        return average;
    }
})()

let myArr = [1, 2, 3, 4, 5];

console.log("Last Index")
console.log(myArr.last()); // 5
console.log("_______")
console.log("Skip 2");
console.log(myArr.skip(2)); // [3,4,5]
console.log("_______")
console.log("Take 3");
console.log(myArr.take(3)); // [1,2,3]
console.log("_______")
console.log("Sum elements");
console.log(myArr.sum()); // 15
console.log("_______")
console.log("Average elements");
console.log(myArr.average()); // 3
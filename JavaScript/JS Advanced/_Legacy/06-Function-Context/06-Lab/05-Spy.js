function Spy(obj, method) {
    const spy = {count: 0};
    
    let inputFunction = obj[method];

    obj[method] = function (...args) {
        this.count++;
        return inputFunction.apply(obj, args);
    }.bind(spy);

    return spy;
}

let obj = {
    method:()=>"invoked"
}
let spy = Spy(obj,"method");

obj.method();
obj.method();
obj.method();

console.log(spy) // { count: 3 }

let spy2 = Spy(console,"log");

console.log(spy2); // { count: 1 }
console.log(spy2); // { count: 2 }
console.log(spy2); // { count: 3 }

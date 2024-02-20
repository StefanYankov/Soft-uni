function solve() {
  const obj = {
    elements: [],
    add: function (element) {
      this.elements.push(element);
      this.elements.sort((a, b) => a - b);
    },
    remove: function (index) {
      this.elements.splice(index, 1);
    },
    get: function (index) {
      return this.elements[index];
    },
    size: function () {
      return this.elements.size;
    },
  };
  return obj;
}

let list = solve();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));

function add(num) {
  let sum = num;

  function innerAdd(nextNum) {
    sum += nextNum;
    return innerAdd;
  }

  innerAdd.toString = function () {
    return sum;
  };

  return innerAdd;
}
console.log(add(1)); // Output: 1
console.log(add(1)(6)(-3)); // Output: 4

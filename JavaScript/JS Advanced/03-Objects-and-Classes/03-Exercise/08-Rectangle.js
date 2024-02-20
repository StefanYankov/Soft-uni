function rectangle(width = 0, height = 0, color = "") {
  const obj = {
    width: Number(width),
    height: Number(height),
    // make the first letter only to upper case
    color: color.charAt(0).toUpperCase() + color.slice(1),
    calcArea: function () {
      return this.width * this.height;
    },
  };
  return obj;
}

let rect = rectangle(4, 5, "red");
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());

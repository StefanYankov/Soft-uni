class Rectangle {

    constructor(width, height, color){

        this.width = width;
        this.height = height;
        this.color = color;
    }

    calcArea(){
        const area = this.width * this.height;
        return area;
    }
}

let rect = new Rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());

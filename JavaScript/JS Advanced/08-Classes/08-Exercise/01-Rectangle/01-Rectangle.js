class Rectangle {
    _width;
    _height;
    _color;

    constructor(width, height, color) {
        this.width = width;
        this.height = height;
        this.color = color;
    }

    get width() {
        return this._width;
    }

    set width(width) {
        this._width = width;
    }

    get height() {
        return this._height;
    }

    set height(height) {
        this._height = height;
    }

    get color() {
        return this._color;
    }

    set color(color) {
        this._color = color;
    }

    calcArea() {
        return this.height * this.width;
    }
}

let rect = new Rectangle(4, 5, 'Red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());

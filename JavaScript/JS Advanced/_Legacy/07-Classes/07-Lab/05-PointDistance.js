class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(firstPoint, secondPoint) {
        let distance = Math.sqrt(Math.pow(firstPoint.x - secondPoint.x, 2) + Math.pow(firstPoint.y - secondPoint.y, 2))
        return distance;
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));

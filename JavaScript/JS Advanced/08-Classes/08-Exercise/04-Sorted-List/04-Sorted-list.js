class List {
    _list = [];

    add(number) {
        this._list.push(number);
        this._sortList();
    }

    remove(index) {
        this._ensureInside(index);
        this._list.splice(index, 1);
    }

    get(index) {
        this._ensureInside(index);
        return this._list[index];
    }

    get size() {
        return this._list.length;
    }

    _ensureInside(index) {
        if (!this._isInsideList(index)) {
            throw RangeError("Index out of range!");
        }
    }

    _isInsideList(index) {
        return 0 <= index && index < this._list.length;
    }

    _sortList() {
        this._list.sort((a, b) => a - b);
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);

console.log(list.hasOwnProperty('size'));
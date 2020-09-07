function solution (){
    let text = '';

    function append(input) {
        text += input;
    }

    function removeStart(index) {
        text = text.substring(index);

    }

    function removeEnd(index) {
        text = text.substring(0, text.length - index);
    }

    function print(){
        console.log(text);
    }

    return {
        append,
        removeEnd,
        removeStart,
        print
    }
};

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);


let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();

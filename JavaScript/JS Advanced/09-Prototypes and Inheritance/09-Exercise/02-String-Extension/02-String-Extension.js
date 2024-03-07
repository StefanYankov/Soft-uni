(function () {
    String.prototype.ensureStart = function (inputString) {

        let output = this.toString();
        if (!this.startsWith(inputString)) {
            output = `${inputString}${this.toString()}`
        }
        debugger
        return output
    };

    String.prototype.ensureEnd = function (inputString) {

        let output = this.toString();
        if (!this.endsWith(inputString)) {
            output = `${this.toString()}${inputString}`
        }
        return output
    };

    String.prototype.isEmpty = function () {
        return this.length === 0;
    };

    String.prototype.truncate = function (numberOfCharsToKeep) {
        const length = this.length;

        if (numberOfCharsToKeep < 4) {
            return '.'.repeat(numberOfCharsToKeep);
        };

        if (length <= numberOfCharsToKeep) {
            return this.toString();
        };

        if (this.includes(' ')) {
            const wordsArray = this.split(' ');
            let output = [];

            for (const word of wordsArray) {
                if (output.join(' ').length + word.length + 3 <= numberOfCharsToKeep) {
                    output.push(word);
                } else {
                    break;
                }
            }

            return `${output.join(' ')}${'...'}`
        }
        return `${this.slice(0, numberOfCharsToKeep - 3)}${'...'}`;

    };

    String.format = function (inputString, ...params) {
        for (let i = 0; i < params.length; i++) {
            inputString = inputString.replace(`{${i}}`, params[i]);
        }
        return inputString;
    }
})();

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
str = String.format('jumps {0} {1}',
    'dog');

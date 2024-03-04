import { expect } from 'chai';
import { isOddOrEven } from './02-Even-Or-Odd.js';

describe('Even or odd tests', function () {
    it('should returns even if the string length is even', () => {
        const evenLengthString = 'even';
        expect(isOddOrEven(evenLengthString)).to.equal('even');
    });

    it('should returns odd if the string length is odd', () => {
        const oddLengthString = 'odd';
        expect(isOddOrEven(oddLengthString)).to.equal('odd');
    });

    it('should return even if the string is empty', () => {
        const emptyString = '';
        expect(isOddOrEven(emptyString)).to.equal('even');
    })

    it('should return undefined if the input is an empty value', () => {
        expect(isOddOrEven()).to.equal(undefined);
    });

    it('should return undefined if value is not a string', () => {
        const nonStringValue = 0;
        expect(isOddOrEven(nonStringValue)).to.equal(undefined);

    });
});
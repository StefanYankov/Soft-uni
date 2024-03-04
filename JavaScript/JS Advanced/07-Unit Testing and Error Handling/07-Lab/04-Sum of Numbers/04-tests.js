import { expect } from 'chai';
import { sum } from './04-Sum of Numbers.js';

describe('Test suite', function () {
    // happy path
    it('works with numer array', () => {
        const arr = [1, 1, 1];
        expect(sum(arr)).to.equal(3);
    });
    // // error cases - no error cases in the requirements
    // it('throws error for non-array params', () => {
    //     const arr = 1;
    //     expect(() => sum(arr)).to.throw();
    // });

    //common edge cases
    it('returns 0 for empty array', () => {
        const arr = [];
        expect(arr).to.equal(0);
    });

    it('returns 1 for array with 1 element', () => {
        const arr = [1];
        expect(arr).to.equal(1);
    });
});
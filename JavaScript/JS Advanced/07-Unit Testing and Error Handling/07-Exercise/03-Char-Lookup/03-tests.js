import { expect } from 'chai';
import { lookupChar } from './03-Char-Lookup.js';

describe('Char lookup test suite', function () {
    const testString1 = 'Serafim';
    const testString2 = 'Gerasimoff';

    it('should return correct character for valid index in string1', () => {
        expect(lookupChar(testString1, 0)).to.equal('S');
    });

    it('should return correct character for valid index in string2', () => {
        expect(lookupChar(testString2, 0)).to.equal('G');
    });

    it('should return "Incorrect index" for negative index', () => {
        expect(lookupChar(testString2, -1)).to.equal('Incorrect index');
    });

    it('should return "Incorrect index" for index beyond string length', () => {
        expect(lookupChar(testString2, 10)).to.equal('Incorrect index');
    });

    it('should return undefined for non-string input', () => {
        const testObject = {};
        const testInteger = 42;
        expect(lookupChar(testObject, 10)).to.equal(undefined);
        expect(lookupChar(testInteger, 10)).to.equal(undefined);
    });

    it('should return undefined for non-integer index', () => {
        expect(lookupChar(testString1, '0')).to.equal(undefined);
    });

    it('should return undefined for non-integer index', () => {
        expect(lookupChar(testString1, 0.1)).to.be.undefined;
    });
})
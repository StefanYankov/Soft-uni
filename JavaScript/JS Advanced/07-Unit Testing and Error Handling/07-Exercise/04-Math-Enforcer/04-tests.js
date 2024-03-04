import { expect } from 'chai';
import { mathEnforcer } from './04-Math-Enforcer.js';

describe('Math enforcer test suite', function () {
    describe('Add five', function () {
        it('should return undefined if input is not a number', () => {
            expect(mathEnforcer.addFive()).to.be.undefined;
            expect(mathEnforcer.addFive('')).to.be.undefined;
            expect(mathEnforcer.addFive('1')).to.be.undefined;
        });

        it('should return correct result for positive integer param', () => {
            expect(mathEnforcer.addFive(5)).to.equal(10);
        });

        it('should return correct result for negative integer param', () => {
            expect(mathEnforcer.addFive(-10)).to.equal(-5);
        });

        it('should return correct result for positive floating point param', () => {
            expect(mathEnforcer.addFive(3.14)).to.be.closeTo(8.14, 0.01);
        });
    });

    describe('subtractTen', () => {
        it('should return undefined for non-number input', () => {
            expect(mathEnforcer.subtractTen()).to.be.undefined;
            expect(mathEnforcer.subtractTen('')).to.be.undefined;
            expect(mathEnforcer.subtractTen('1')).to.be.undefined;
        });

        it('should return correct result for positive integer param', () => {
            expect(mathEnforcer.subtractTen(15)).to.equal(5);
        });

        it('should return correct result for negative integer param', () => {
            expect(mathEnforcer.subtractTen(-5)).to.equal(-15);
        });

        it('should return correct result for positive floating point param', () => {
            expect(mathEnforcer.subtractTen(3.14)).to.be.closeTo(-6.86, 0.01);
        });
    });

    describe('sum', () => {
        it('should return undefined for non-number input', () => {
            expect(mathEnforcer.sum()).to.be.undefined;
            expect(mathEnforcer.sum('', 1)).to.be.undefined;
            expect(mathEnforcer.sum('1', 1)).to.be.undefined;
            expect(mathEnforcer.sum(1, '')).to.be.undefined;
            expect(mathEnforcer.sum(1, '1')).to.be.undefined;
        });

        it('should return correct result for positive integer params', () => {
            expect(mathEnforcer.sum(1, 2)).to.equal(3);
        });

        it('should return correct result for negative integer param', () => {
            expect(mathEnforcer.sum(-1, -2)).to.equal(-3);
        });

        it('should return correct result for positive floating point param', () => {
            expect(mathEnforcer.sum(3.14, 2.1)).to.be.closeTo(5.24, 0.01);
        });
    });
});
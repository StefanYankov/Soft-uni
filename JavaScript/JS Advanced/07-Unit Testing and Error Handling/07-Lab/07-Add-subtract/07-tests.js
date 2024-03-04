import { expect } from 'chai';
import { createCalculator } from './07-Add-subtract.js';

describe('Add subtract createCalculator tests suite', function () {
    it('should contain add(), subtract() and get() methods', () => {
        const calculator = createCalculator();
        expect(calculator).to.have.property('add');
        expect(calculator).to.have.property('subtract');
        expect(calculator).to.have.property('get');
    });
    it('should have initial value 0', () => {
        const calculator = createCalculator();
        expect(calculator.get()).to.equal(0);
    });

    it('should result 3 when you add 1 and 2', () => {
        const calculator = createCalculator();
        calculator.add(1);
        expect(calculator.get()).to.equal(1);

        calculator.add(2);
        expect(calculator.get()).to.equal(3);
    });

    it('should result 3 when you add string "1" and string "2"', () => {
        const calculator = createCalculator();
        calculator.add('1');
        expect(calculator.get()).to.equal(1);

        calculator.add('2');
        expect(calculator.get()).to.equal(3);
    });

    it('should result 7, when you subtract 1 and 2 from 10', () => {
        const calculator = createCalculator();
        calculator.add(10);

        calculator.subtract(1);
        expect(calculator.get()).to.equal(9);

        calculator.subtract(2);
        expect(calculator.get()).to.equal(7);
    });

    it('should result 7, when you subtract string "1" and string "2" from 10', () => {
        const calculator = createCalculator();
        calculator.add(10);

        calculator.subtract('1');
        expect(calculator.get()).to.equal(9);

        calculator.subtract('2');
        expect(calculator.get()).to.equal(7);
    });
})
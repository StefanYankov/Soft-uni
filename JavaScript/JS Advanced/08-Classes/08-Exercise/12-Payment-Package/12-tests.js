import { expect } from 'chai';
import { PaymentPackage } from './12-Payment-Package.js';

/* alternative 
const {describe} = require('mocha');
let { PaymentPackage } = require('./12-Payment-Package.js');
let { expect } = require('chai');
 */

describe('Payment package test suite', function () {
    describe('constructor test', () => {
        it('Can be initiated with two parameters', () => {
            const obj = new PaymentPackage('Niki', 100);
            expect(obj).to.be.an.instanceOf(PaymentPackage);
            expect(obj.name).to.equal('Niki');
            expect(obj.value).to.equal(100);
            expect(obj.VAT).to.equal(20);
            expect(obj.active).to.be.true;
        });

        it('should throw an exception if initiated with a no-string name or empty string', () => {
            expect(() => new PaymentPackage(null, 100)).to.throw(Error, 'Name must be a non-empty string');
            expect(() => new PaymentPackage(undefined, 100)).to.throw(Error, 'Name must be a non-empty string');
            expect(() => new PaymentPackage('', 100)).to.throw(Error, 'Name must be a non-empty string');
            expect(() => new PaymentPackage(1, 100)).to.throw(Error, 'Name must be a non-empty string');
        });

        it('should throw an exception if initiated  with negative value', () => {
            expect(() => new PaymentPackage('Test', -100)).to.throw(Error, 'Value must be a non-negative number');
        });

        it('should throw an exception if initiated with a non-number value ', () => {
            expect(() => new PaymentPackage('Test', '-100')).to.throw(Error, 'Value must be a non-negative number');
        });
    });

    describe('value', () => {
        it('Set positive value sets the value', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            paymentPackage.value = 42;
            expect(paymentPackage.value).to.equal(42);
            paymentPackage.value = 0;
            expect(paymentPackage.value).to.equal(0);
        });

        it('Set negative value throws exception', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            expect(() => paymentPackage.value = -42).to.throw(Error, 'Value must be a non-negative number');
        });

        it('Set value not number throws exception', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            expect(() => paymentPackage.value = 'test').to.throw(Error, 'Value must be a non-negative number');
        });
    });

    describe('name', () => {
        it('Set non empty string value sets the name', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            paymentPackage.name = 'The answer is 42!';
            expect(paymentPackage.name).to.equal('The answer is 42!');
        });

        it('Set empty string throws exception', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            expect(() => paymentPackage.name = '').to.throw(Error, 'Name must be a non-empty string');
        });

        it('Set non-string throws exception', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            expect(() => paymentPackage.name = 42).to.throw(Error, 'Name must be a non-empty string');
            expect(() => paymentPackage.name = null).to.throw(Error, 'Name must be a non-empty string');
            expect(() => paymentPackage.name = undefined).to.throw(Error, 'Name must be a non-empty string');
        });
    });

    describe('VAT', () => {
        it('Set positive value sets the value', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            paymentPackage.VAT = 42;
            expect(paymentPackage.VAT).to.equal(42);
        });

        it('Set negative value throws exception', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            expect(() => paymentPackage.VAT = -42).to.throw(Error, 'VAT must be a non-negative number');
        });

        it('Set value not number throws exception', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            expect(() => paymentPackage.VAT = 'test').to.throw(Error, 'VAT must be a non-negative number');
        });
    });

    describe('active', () => {
        it('Set active to boolean sets active', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            paymentPackage.active = false;
            expect(paymentPackage.active).to.be.false;
        });

        it('Set active not boolean throws exception', () => {
            const paymentPackage = new PaymentPackage('Test', 100);
            expect(() => paymentPackage.active = 'test').to.throw(Error, 'Active status must be a boolean');
        });
    });

    describe('toString override tests', () => {
        it('toString works correct', () => {
            const paymentPackage = new PaymentPackage('HR Services', 1500);
            expect(paymentPackage.toString()).to.equal(
                'Package: HR Services\n' +
                '- Value (excl. VAT): 1500\n' +
                '- Value (VAT 20%): 1800'
            );
        });

        it('toString works correct if inactive', () => {
            const paymentPackage = new PaymentPackage('HR Services', 1500);
            paymentPackage.active = false;
            expect(paymentPackage.toString()).to.equal(
                'Package: HR Services (inactive)\n' +
                '- Value (excl. VAT): 1500\n' +
                '- Value (VAT 20%): 1800'
            );
        });
    });
});
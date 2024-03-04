import { expect } from 'chai';
import { isSymmetric } from './05-Check-for-Summetry.js';

describe('Test suite', function () {

    it("Should return false for any input that isn’t of the correct type", () => {
        const array = 5;
        expect(isSymmetric(array)).to.equal(false);
    })

    it("Should return true if the input array is symmetric - type number", () => {
        const symmetricArray = [1, 0, 0, 1];
        expect(isSymmetric(symmetricArray)).to.equal(true, "true");
    })

    it("Should return true if the input array is symmetric - type string", () => {
        const symmetricArray = ["C#", "JavaScript", "JavaScript", "C#"];
        expect(isSymmetric(symmetricArray)).to.equal(true, "true");
    })

    it("Should return false if the input array is NOT symmetric", () => {
        const nonSymmetricArray = [1, 2, 3, 4];
        expect(isSymmetric(nonSymmetricArray)).to.equal(false);
    })

    it("Should return false if the input array is NOT symmetric, due to different array element types", () => {
        const nonSymmetricArray = [1, 0, 0, '1'];
        expect(isSymmetric(nonSymmetricArray)).to.equal(false);
    })
});
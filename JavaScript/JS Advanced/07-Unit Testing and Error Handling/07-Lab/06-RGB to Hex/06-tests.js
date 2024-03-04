import { expect } from 'chai';
import { rgbToHexColor } from './06-RGB-to-Hex.js';

describe('RGB to Hex test', function () {
    it('should convert 0,0,0 RGB to #000000 hexadecimal - black', () => {

        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    });

    it('should convert 255,255,255 RGB to #FFFFFF hexadecimal - white', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    });
    it('should convert 0, 255, 0 RGB to #00FF00 - green', () => {
        expect(rgbToHexColor(0, 255, 0)).to.equal('#00FF00');
    });

    it('should return undefined if one of the numbers is below 0', () => {
        expect(rgbToHexColor(-1, 0, 0)).to.equal(undefined);
        expect(rgbToHexColor(0, -1, 0)).to.equal(undefined);
        expect(rgbToHexColor(0, 0, -1)).to.equal(undefined);
    });
    it('should return undefined if one of the numbers is above 255', () => {
        expect(rgbToHexColor(256, 0, 0)).to.equal(undefined);
        expect(rgbToHexColor(0, 256, 0)).to.equal(undefined);
        expect(rgbToHexColor(0, 0, 256)).to.equal(undefined);
    });

    it('should return undefined if one of the numbers is not a number', () => {
        expect(rgbToHexColor('a', 0, 0)).to.equal(undefined);
        expect(rgbToHexColor(0, 'a', 0)).to.equal(undefined);
        expect(rgbToHexColor(0, 0, 'a')).to.equal(undefined);
    });

    it('should return undefined if we are missing a parameter', () => {
        expect(rgbToHexColor()).to.equal(undefined);
        expect(rgbToHexColor(0)).to.equal(undefined);
        expect(rgbToHexColor(0, 0)).to.equal(undefined);
    });
});
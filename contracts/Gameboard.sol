// SPDX-License-Identifier: UNLICENSED
pragma solidity 0.8.16;

/**
 * @title
 * @author
 * @notice
 */
contract Gameboard {
    uint8 public width;
    uint8 public height;
    uint32 public color1;
    uint32 public color2;

    constructor(uint8 width_, uint8 height_, uint32 color1_, uint32 color2_) {
        width = width_;
        height = height_;
        color1 = color1_;
        color2 = color2_;
    }

    /**
     * @notice returns gameboard parameters
     * @return width
     * @return height
     * @return color1
     * @return color2
     */
    function getBoard() external view returns (uint8, uint8, uint32, uint32) {
        return (width, height, color1, color2);
    }
}

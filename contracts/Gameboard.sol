// SPDX-License-Identifier: UNLICENSED
pragma solidity 0.8.16;

struct GameboardParams {
    uint8 width;
    uint8 height;
    uint32 color1;
    uint32 color2;
}

/**
 * @title
 * @author
 * @notice
 */
contract Gameboard {
    GameboardParams public gameboardParams;

    constructor(GameboardParams memory gameboardParams_) {
        gameboardParams = gameboardParams_;
    }

    /**
     * @notice returns gameboard parameters
     * @return gameboardParams
     */
    function getBoard() external view returns (GameboardParams memory) {
        return gameboardParams;
    }

    /**
     * @notice set new gameboard params
     * @param gameboardParams_  new gameboard params
     */
    function setBoard(GameboardParams calldata gameboardParams_) external {
        gameboardParams = gameboardParams_;
    }
}

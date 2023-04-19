import { IERC20 } from "@openzeppelin/contracts/token/ERC20/IERC20.sol";
// SPDX-License-Identifier: UNLICENSED
pragma solidity 0.8.16;

struct GameboardParams {
    uint8 width;
    uint8 height;
    uint32 color1;
    uint32 color2;
    IERC20 token;
    uint256 initialPool;
}

struct GameboardData {
    uint256 creationDate;
}

/**
 * @title
 * @author
 * @notice
 */
contract Gameboard {
    GameboardParams public gameboardParams;
    GameboardData public gameboardData;

    constructor(GameboardParams memory gameboardParams_) {
        gameboardParams = gameboardParams_;
        gameboardData.creationDate = block.timestamp;
    }

    /**
     * @notice returns gameboard parameters
     * @return gameboardParams
     */
    function getBoard() external view returns (GameboardParams memory, GameboardData memory) {
        return (gameboardParams, gameboardData);
    }

    /**
     * @notice set new gameboard params
     * @param gameboardParams_  new gameboard params
     */
    function setBoard(GameboardParams calldata gameboardParams_) external {
        gameboardParams = gameboardParams_;
    }
}

// SPDX-License-Identifier: UNLICENSED
pragma solidity 0.8.16;

import { Gameboard, GameboardParams } from "./Gameboard.sol";

/**
 * @title
 * @author
 * @notice
 */
contract GameboardFactory {
    // Events
    event NewGameboard(address indexed creator_, uint256 id_, GameboardParams gameboardParams_);

    Gameboard[] public gameboards;

    function createGameboard(GameboardParams calldata gameboardParams_) external {
        Gameboard gameboard = new Gameboard(gameboardParams_);
        gameboards.push(gameboard);
        emit NewGameboard(msg.sender, gameboards.length, gameboardParams_);
    }

    function getGameboardsLength() external view returns (uint256) {
        return gameboards.length;
    }

    function getGameboard(uint256 id_) external view returns (Gameboard) {
        return gameboards[id_];
    }

    function getAllGameboards()
        external
        view
        returns (Gameboard[] memory gameboards_, GameboardParams[] memory gameboardParams_)
    {
        uint256 length = gameboards.length;
        for (uint256 i = 0; i < length; ) {
            gameboards_[i] = gameboards[i];
            gameboardParams_[i] = gameboards[i].getBoard();
            unchecked {
                i += 1;
            }
        }
        return (gameboards_, gameboardParams_);
    }
}

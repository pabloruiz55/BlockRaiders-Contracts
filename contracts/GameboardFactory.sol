// SPDX-License-Identifier: UNLICENSED
pragma solidity 0.8.16;

import { Gameboard, GameboardParams, GameboardData } from "./Gameboard.sol";
import { SafeERC20 } from "@openzeppelin/contracts/token/ERC20/utils/SafeERC20.sol";

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
        SafeERC20.safeTransferFrom(
            gameboardParams_.token,
            msg.sender,
            address(gameboard),
            gameboardParams_.initialPool
        );
        emit NewGameboard(msg.sender, gameboards.length, gameboardParams_);
    }

    function createFreeGameboard(GameboardParams calldata gameboardParams_) external {
        Gameboard gameboard = new Gameboard(gameboardParams_);
        gameboards.push(gameboard);
        emit NewGameboard(msg.sender, gameboards.length, gameboardParams_);
    }

    function getGameboardsLength() external view returns (uint256) {
        return gameboards.length;
    }

    function getBoardById(
        uint256 id_
    )
        external
        view
        returns (Gameboard gameboard, GameboardParams memory gameboardParams_, GameboardData memory gameboardData_)
    {
        gameboard = gameboards[id_];
        (gameboardParams_, gameboardData_) = gameboards[id_].getBoard();
        return (gameboard, gameboardParams_, gameboardData_);
    }

    function getAllBoards()
        external
        view
        returns (
            Gameboard[] memory gameboards_,
            GameboardParams[] memory gameboardsParams_,
            GameboardData[] memory gameboardsData_
        )
    {
        uint256 length = gameboards.length;
        for (uint256 i = 0; i < length; ) {
            gameboards_[i] = gameboards[i];
            (gameboardsParams_[i], gameboardsData_[i]) = gameboards[i].getBoard();
            unchecked {
                i += 1;
            }
        }
        return (gameboards_, gameboardsParams_, gameboardsData_);
    }
}

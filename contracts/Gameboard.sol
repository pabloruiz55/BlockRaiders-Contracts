// SPDX-License-Identifier: UNLICENSED
pragma solidity 0.8.16;
import { IERC20 } from "@openzeppelin/contracts/token/ERC20/IERC20.sol";
import { SafeERC20 } from "@openzeppelin/contracts/token/ERC20/utils/SafeERC20.sol";

struct GameboardParams {
    uint8 width;
    uint8 height;
    uint32 color1;
    uint32 color2;
    IERC20 token; // TODO: if == address(0) the pool could be in ETH
    uint256 initialPool; // TODO: could be lower type
    uint256 bet; // TODO: could be lower type
}

struct GameboardData {
    GameStatus gameStatus;
    uint256 creationDate;
    uint256 totalPool;
}

enum GameStatus {
    iddle,
    started,
    finished
}

/**
 * @title
 * @author
 * @notice
 */
contract Gameboard {
    // Custom Errors
    error InsufficientBet();
    error GameAlreadyStarted();
    error GameAlreadyFinished();

    GameboardParams public gameboardParams;
    GameboardData public gameboardData;

    constructor(GameboardParams memory gameboardParams_) {
        gameboardParams = gameboardParams_;
        gameboardData = GameboardData({
            gameStatus: GameStatus.iddle,
            creationDate: block.timestamp,
            totalPool: gameboardParams_.initialPool
        });
    }

    function play(uint256 bet_) external {
        if (bet_ < gameboardParams.bet) revert InsufficientBet();
        if (gameboardData.gameStatus == GameStatus.started) revert GameAlreadyStarted();
        if (gameboardData.gameStatus == GameStatus.finished) revert GameAlreadyFinished();

        gameboardData.gameStatus = GameStatus.started;
        gameboardData.totalPool += bet_;
        SafeERC20.safeTransferFrom(gameboardParams.token, msg.sender, address(this), bet_);
    }

    function playFree(uint256 bet_) external {
        if (bet_ < gameboardParams.bet) revert InsufficientBet();
        if (gameboardData.gameStatus == GameStatus.started) revert GameAlreadyStarted();
        if (gameboardData.gameStatus == GameStatus.finished) revert GameAlreadyFinished();

        gameboardData.gameStatus = GameStatus.started;
        gameboardData.totalPool += bet_;
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

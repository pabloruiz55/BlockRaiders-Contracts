import { getNamedAccounts, ethers } from "hardhat";
import { ContractTransaction } from "ethers";
import { expect } from "chai";
import { BigNumber } from "@ethersproject/bignumber";
import { Address } from "hardhat-deploy/types";
import { Gameboard, GameboardFactory, Gameboard__factory } from "../typechain";
import { GameboardParamsStruct, GridDataStruct, GridDataStructOutput } from "../typechain/contracts/GameboardFactory";
import { CONSTANTS, pEth } from "./helpers/utils";
import { fixtureDeployed } from "./fixture";

describe("Feature: create gameboards", () => {
  let deployer: Address;
  let gameboardFactory: GameboardFactory;
  let gameboard: Gameboard;
  let tx: ContractTransaction;

  const gameboardParams: GameboardParamsStruct = {
    width: 10,
    height: 16,
    color1: parseInt("0xff0000", 16),
    color2: parseInt("0x00ff00", 16),
    token: CONSTANTS.ZERO_ADDRESS,
    initialPool: pEth(10),
    bet: pEth(1),
  };

  describe("GIVEN a GameboardFactory implementation deployed", () => {
    before(async () => {
      ({ deployer } = await getNamedAccounts());
      const fixtureDeploy = fixtureDeployed();
      ({ gameboardFactory } = await fixtureDeploy());
    });
    describe("WHEN a gameboard is created", () => {
      before(async () => {
        tx = await gameboardFactory.createFreeGameboard(gameboardParams);
        gameboard = Gameboard__factory.connect(await gameboardFactory.gameboards(0), ethers.provider.getSigner());
      });
      it("THEN gameboards length increase by 1", async () => {
        expect(await gameboardFactory.getGameboardsLength()).to.be.equal(1);
      });
      it("THEN NewGameboard event is emitted", async () => {
        // creator: deployer
        // gameboard: gameboards(0)
        // id: 1
        // parameters: gameboardParams
        await expect(tx)
          .to.emit(gameboardFactory, "NewGameboard")
          .withArgs(deployer, gameboard.address, 1, Object.values(gameboardParams));
      });
      describe("AND a grid (0,0) is set with terrain 1", () => {
        before(async () => {
          await gameboard.setGrid(0, 0, { terrain: 1 });
        });
        it("THEN grid (0,0) has terrain 1", async () => {
          expect((await gameboard.getGrid(0, 0))[0].toNumber()).to.be.equal(1);
        });
      });
      describe("AND all the grids are set with terrain 1", () => {
        const grid: GridDataStruct[][] = new Array(16)
          .fill({ terrain: 1 })
          .map(() => new Array(10).fill({ terrain: 1 }));
        before(async () => {
          await gameboard.setAllGrids(grid);
        });
        it("THEN all grids have terrain 1", async () => {
          let currentGrids = await gameboard.getAllGrids();
          currentGrids = currentGrids.map((v: any) =>
            v.map((v2: GridDataStructOutput) => v2.map((v3: BigNumber) => v3.toNumber())),
          );
          expect(currentGrids).to.be.deep.equal(grid.map((v: any) => v.map((v2: number) => Object.values(v2))));
        });
      });
    });
  });
});

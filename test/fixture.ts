import { deployments } from "hardhat";
import memoizee from "memoizee";
import { GameboardFactory, GameboardFactory__factory } from "../typechain";

export const fixtureDeployed = memoizee(
  (): (() => Promise<{
    gameboardFactory: GameboardFactory;
  }>) => {
    return deployments.createFixture(async ({ ethers }) => {
      await deployments.fixture();
      const signer = ethers.provider.getSigner();

      const deployedGameboardFactory = await deployments.getOrNull("GameboardFactory");
      if (!deployedGameboardFactory) throw new Error("No GameboardFactory deployed.");
      const gameboardFactory: GameboardFactory = GameboardFactory__factory.connect(
        deployedGameboardFactory.address,
        signer,
      );

      return {
        gameboardFactory,
      };
    });
  },
);

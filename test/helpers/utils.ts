import { ethers, network } from "hardhat";
import { BigNumber } from "@ethersproject/bignumber";
import { mineUpTo } from "@nomicfoundation/hardhat-network-helpers";

export const GAS_LIMIT_PATCH = 30000000;

export function pEth(eth: string | number): BigNumber {
  let ethStr: string;
  if (typeof eth === "number") ethStr = eth.toLocaleString("fullwide", { useGrouping: false }).replace(",", ".");
  else ethStr = eth;
  return ethers.utils.parseEther(ethStr);
}

export type Balance = BigNumber;

export const ERRORS = {
  INSUFFICIENT_BET: "InsufficientBet",
};

export const CONSTANTS = {
  ZERO_ADDRESS: ethers.constants.AddressZero,
  MAX_UINT256: ethers.constants.MaxUint256,
  MAX_BALANCE: ethers.constants.MaxUint256.div((1e17).toString()),
  PRECISION: BigNumber.from((1e18).toString()),
  ONE: BigNumber.from((1e18).toString()),
};

export function mineNBlocks(blocks: number, secondsPerBlock: number = 1): Promise<any> {
  return network.provider.send("hardhat_mine", ["0x" + blocks.toString(16), "0x" + secondsPerBlock.toString(16)]);
}

export function getBlock(block: any) {
  return ethers.provider.getBlock(block);
}

export { mineUpTo };

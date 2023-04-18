import { HardhatRuntimeEnvironment } from "hardhat/types";
import { DeployFunction } from "hardhat-deploy/types";

const deployFunc: DeployFunction = async (hre: HardhatRuntimeEnvironment) => {
  const { deployments, getNamedAccounts } = hre;
  const { deployer } = await getNamedAccounts();
  const { deploy } = deployments;
  const deployResult = await deploy("Gameboard", {
    args: [5, 6, 0xff0000, 0x00ff00],
    from: deployer,
    gasLimit: 6800000,
  });
  console.log(`"Gameboard deployed at ${deployResult.address}`);
  return hre.network.live; // prevents re execution on live networks
};
export default deployFunc;

deployFunc.id = "deployed_Gameboard"; // id required to prevent re-execution
deployFunc.tags = ["Gameboard"];

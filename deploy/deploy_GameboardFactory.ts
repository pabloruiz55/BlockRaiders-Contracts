import { HardhatRuntimeEnvironment } from "hardhat/types";
import { DeployFunction } from "hardhat-deploy/types";

const deployFunc: DeployFunction = async (hre: HardhatRuntimeEnvironment) => {
  const { deployments, getNamedAccounts } = hre;
  const { deployer } = await getNamedAccounts();
  const { deploy } = deployments;
  const deployResult = await deploy("GameboardFactory", {
    from: deployer,
    gasLimit: 680000,
  });
  console.log(`"GameboardFactory deployed at ${deployResult.address}`);
  return hre.network.live; // prevents re execution on live networks
};
export default deployFunc;

deployFunc.id = "deployed_GameboardFactory"; // id required to prevent re-execution
deployFunc.tags = ["GameboardFactory"];

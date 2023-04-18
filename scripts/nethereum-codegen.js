const codegen = require("nethereum-codegen");
const Gameboard = require("../artifacts/contracts/Gameboard.sol/Gameboard.json");

async function main() {
  codegen.generateAllClasses(
    JSON.stringify(Gameboard.abi),
    Gameboard.bytecode,
    "Gameboard",
    "Gameboard",
    "exports/Gameboard.csproj",
    0,
  );
}

main()
  .then(() => process.exit(0))
  .catch(error => {
    console.error(error);
    process.exit(1);
  });

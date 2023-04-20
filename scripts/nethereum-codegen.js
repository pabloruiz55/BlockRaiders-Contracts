const codegen = require("nethereum-codegen");
const Gameboard = require("../artifacts/contracts/Gameboard.sol/Gameboard.json");
const GameboardFactory = require("../artifacts/contracts/GameboardFactory.sol/GameboardFactory.json");

async function main() {
  codegen.generateAllClasses(
    JSON.stringify(Gameboard.abi),
    Gameboard.bytecode,
    "Gameboard",
    "Gameboard",
    "exports/Gameboard.csproj",
    0,
  );

  codegen.generateAllClasses(
    JSON.stringify(GameboardFactory.abi),
    GameboardFactory.bytecode,
    "GameboardFactory",
    "GameboardFactory",
    "exports/GameboardFactory.csproj",
    0,
  );
}

main()
  .then(() => process.exit(0))
  .catch(error => {
    console.error(error);
    process.exit(1);
  });

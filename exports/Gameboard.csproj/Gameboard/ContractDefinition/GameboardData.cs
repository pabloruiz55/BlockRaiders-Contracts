using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Gameboard.Gameboard.ContractDefinition
{
    public partial class GameboardData : GameboardDataBase { }

    public class GameboardDataBase 
    {
        [Parameter("tuple[][]", "grids", 1)]
        public virtual List<List<GridData>> Grids { get; set; }
        [Parameter("uint8", "gameStatus", 2)]
        public virtual byte GameStatus { get; set; }
        [Parameter("uint256", "creationDate", 3)]
        public virtual BigInteger CreationDate { get; set; }
        [Parameter("uint256", "totalPool", 4)]
        public virtual BigInteger TotalPool { get; set; }
    }
}

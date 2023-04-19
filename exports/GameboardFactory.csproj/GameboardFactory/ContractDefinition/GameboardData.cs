using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace GameboardFactory.GameboardFactory.ContractDefinition
{
    public partial class GameboardData : GameboardDataBase { }

    public class GameboardDataBase 
    {
        [Parameter("uint8", "gameStatus", 1)]
        public virtual byte GameStatus { get; set; }
        [Parameter("uint256", "creationDate", 2)]
        public virtual BigInteger CreationDate { get; set; }
        [Parameter("uint256", "totalPool", 3)]
        public virtual BigInteger TotalPool { get; set; }
    }
}

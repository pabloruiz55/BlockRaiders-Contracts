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
        [Parameter("uint256", "creationDate", 1)]
        public virtual BigInteger CreationDate { get; set; }
    }
}

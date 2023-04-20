using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Gameboard.Gameboard.ContractDefinition
{
    public partial class GridData : GridDataBase { }

    public class GridDataBase 
    {
        [Parameter("uint256", "terrain", 1)]
        public virtual BigInteger Terrain { get; set; }
    }
}

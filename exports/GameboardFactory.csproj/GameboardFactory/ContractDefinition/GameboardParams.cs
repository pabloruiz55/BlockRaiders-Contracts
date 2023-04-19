using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace GameboardFactory.GameboardFactory.ContractDefinition
{
    public partial class GameboardParams : GameboardParamsBase { }

    public class GameboardParamsBase 
    {
        [Parameter("uint8", "width", 1)]
        public virtual byte Width { get; set; }
        [Parameter("uint8", "height", 2)]
        public virtual byte Height { get; set; }
        [Parameter("uint32", "color1", 3)]
        public virtual uint Color1 { get; set; }
        [Parameter("uint32", "color2", 4)]
        public virtual uint Color2 { get; set; }
        [Parameter("address", "token", 5)]
        public virtual string Token { get; set; }
        [Parameter("uint256", "initialPool", 6)]
        public virtual BigInteger InitialPool { get; set; }
        [Parameter("uint256", "bet", 7)]
        public virtual BigInteger Bet { get; set; }
    }
}

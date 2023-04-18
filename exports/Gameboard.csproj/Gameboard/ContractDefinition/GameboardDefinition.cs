using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Gameboard.Gameboard.ContractDefinition
{


    public partial class GameboardDeployment : GameboardDeploymentBase
    {
        public GameboardDeployment() : base(BYTECODE) { }
        public GameboardDeployment(string byteCode) : base(byteCode) { }
    }

    public class GameboardDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x6080346100b757601f6102f538819003918201601f19168301916001600160401b038311848410176100bc578084926080946040528339810103126100b757610047816100d2565b9065ffffffff000061005b602083016100d2565b61ff00610076606061006f604087016100e0565b95016100e0565b60ff69ffffffff0000000000006000549260301b1696169060018060501b031916179160081b16179160101b16171760005560405161020390816100f28239f35b600080fd5b634e487b7160e01b600052604160045260246000fd5b519060ff821682036100b757565b519063ffffffff821682036100b75756fe60806040818152600436101561001457600080fd5b600091823560e01c9081630ef26743146101ad575080633264a34b146101675780635115bdff146101425780639ededf7714610123578063bb632c4d1461008c5763ef60f12a1461006457600080fd5b3461008857816003193601126100885763ffffffff6020925460301c169051908152f35b5080fd5b50346100885760803660031901126100885760043560ff811680910361011f576024359060ff8216820361011b576044359063ffffffff9283831683036101175760643593841684036101175761ff0065ffffffff00009269ffffffff00000000000088549660301b169569ffffffffffffffffffff1916179160081b16179160101b161717825551f35b8580fd5b8380fd5b8280fd5b503461008857816003193601126100885760ff60209254169051908152f35b503461008857816003193601126100885763ffffffff6020925460101c169051908152f35b5034610088578160031936011261008857608091549080519160ff8116835260ff8160081c16602084015263ffffffff91828260101c169084015260301c166060820152f35b83903461008857816003193601126100885760ff6020925460081c168152f3fea2646970667358221220a877c66767108c8c1eb4263b90d9f64fe7360ddfa7c00c268ab49b503594f1ba64736f6c63430008100033";
        public GameboardDeploymentBase() : base(BYTECODE) { }
        public GameboardDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint8", "width_", 1)]
        public virtual byte Width { get; set; }
        [Parameter("uint8", "height_", 2)]
        public virtual byte Height { get; set; }
        [Parameter("uint32", "color1_", 3)]
        public virtual uint Color1 { get; set; }
        [Parameter("uint32", "color2_", 4)]
        public virtual uint Color2 { get; set; }
    }

    public partial class Color1Function : Color1FunctionBase { }

    [Function("color1", "uint32")]
    public class Color1FunctionBase : FunctionMessage
    {

    }

    public partial class Color2Function : Color2FunctionBase { }

    [Function("color2", "uint32")]
    public class Color2FunctionBase : FunctionMessage
    {

    }

    public partial class GetBoardFunction : GetBoardFunctionBase { }

    [Function("getBoard", typeof(GetBoardOutputDTO))]
    public class GetBoardFunctionBase : FunctionMessage
    {

    }

    public partial class HeightFunction : HeightFunctionBase { }

    [Function("height", "uint8")]
    public class HeightFunctionBase : FunctionMessage
    {

    }

    public partial class SetBoardFunction : SetBoardFunctionBase { }

    [Function("setBoard")]
    public class SetBoardFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "width_", 1)]
        public virtual byte Width { get; set; }
        [Parameter("uint8", "height_", 2)]
        public virtual byte Height { get; set; }
        [Parameter("uint32", "color1_", 3)]
        public virtual uint Color1 { get; set; }
        [Parameter("uint32", "color2_", 4)]
        public virtual uint Color2 { get; set; }
    }

    public partial class WidthFunction : WidthFunctionBase { }

    [Function("width", "uint8")]
    public class WidthFunctionBase : FunctionMessage
    {

    }

    public partial class Color1OutputDTO : Color1OutputDTOBase { }

    [FunctionOutput]
    public class Color1OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }

    public partial class Color2OutputDTO : Color2OutputDTOBase { }

    [FunctionOutput]
    public class Color2OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }

    public partial class GetBoardOutputDTO : GetBoardOutputDTOBase { }

    [FunctionOutput]
    public class GetBoardOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
        [Parameter("uint8", "", 2)]
        public virtual byte ReturnValue2 { get; set; }
        [Parameter("uint32", "", 3)]
        public virtual uint ReturnValue3 { get; set; }
        [Parameter("uint32", "", 4)]
        public virtual uint ReturnValue4 { get; set; }
    }

    public partial class HeightOutputDTO : HeightOutputDTOBase { }

    [FunctionOutput]
    public class HeightOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class WidthOutputDTO : WidthOutputDTOBase { }

    [FunctionOutput]
    public class WidthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }
}

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
        public static string BYTECODE = "0x60806040523461010c5761045560c0813803918261001c81610111565b93849283398101031261010c5761003360c0610111565b61003c8261014c565b9081815261004c6020840161014c565b80602083015261005e6040850161015a565b8060408401526100706060860161015a565b606084018190526080860151909390926001600160a01b038416840361010c5761ff00848360a0809a69ffffffff00000000000098608065ffffffff00009801520151998a91015260ff600054916a0100000000000000000000600160f01b039060501b1698169061ffff60f01b16179160081b16179160101b16179160301b161717600055600155426002556040516102e9908161016c8239f35b600080fd5b6040519190601f01601f191682016001600160401b0381118382101761013657604052565b634e487b7160e01b600052604160045260246000fd5b519060ff8216820361010c57565b519063ffffffff8216820361010c5756fe604060808152600436101561001357600080fd5b600090813560e01c80633264a34b1461018c578063676c14fa146100cc57806388591583146100ae57638a8c2bf51461004b57600080fd5b346100aa57816003193601126100aa5760c091546001549082519260ff8216845260ff8260081c16602085015263ffffffff90818360101c16908501528160301c16606084015260018060a01b039060501c16608083015260a0820152f35b5080fd5b50346100aa57816003193601126100aa576020906002549051908152f35b50346100aa5760c03660031901126100aa5760043560ff81168091036101885782549060243560ff811681036101845760443563ffffffff92838216820361018057606435938416840361018057608435926001600160a01b038416840361017c5761ff0065ffffffff00009269ffffffff00000000000095600160501b600160f01b039060501b169761ffff60f01b16179160081b16179160101b16179160301b161717825560a43560015551f35b8780fd5b8680fd5b8480fd5b8280fd5b50346100aa57816003193601126100aa579060e0918160a06101ae60c0610277565b82815282602082015282848201528260608201528260808201520152816101d56020610277565b526101e060c0610277565b91549060ff82168352602083019160ff8160081c1683528184019163ffffffff808360101c16845260608601818460301c168152608087019260018060a01b03809560501c168452826001549660a08a0197885260ff6102406020610277565b996002548b528185519c51168c52511660208b015251169088015251166060860152511660808401525160a08301525160c0820152f35b6040519190601f01601f1916820167ffffffffffffffff81118382101761029d57604052565b634e487b7160e01b600052604160045260246000fdfea2646970667358221220937bb9505f12d66de63c4eae3ec559dd36fbdb46de8579c3e5476235f2f7fc3964736f6c63430008100033";
        public GameboardDeploymentBase() : base(BYTECODE) { }
        public GameboardDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("tuple", "gameboardParams_", 1)]
        public virtual GameboardParams Gameboardparams { get; set; }
    }

    public partial class GameboardDataFunction : GameboardDataFunctionBase { }

    [Function("gameboardData", "uint256")]
    public class GameboardDataFunctionBase : FunctionMessage
    {

    }

    public partial class GameboardParamsFunction : GameboardParamsFunctionBase { }

    [Function("gameboardParams", typeof(GameboardParamsOutputDTO))]
    public class GameboardParamsFunctionBase : FunctionMessage
    {

    }

    public partial class GetBoardFunction : GetBoardFunctionBase { }

    [Function("getBoard", typeof(GetBoardOutputDTO))]
    public class GetBoardFunctionBase : FunctionMessage
    {

    }

    public partial class SetBoardFunction : SetBoardFunctionBase { }

    [Function("setBoard")]
    public class SetBoardFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "gameboardParams_", 1)]
        public virtual GameboardParams Gameboardparams { get; set; }
    }

    public partial class GameboardDataOutputDTO : GameboardDataOutputDTOBase { }

    [FunctionOutput]
    public class GameboardDataOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "creationDate", 1)]
        public virtual BigInteger CreationDate { get; set; }
    }

    public partial class GameboardParamsOutputDTO : GameboardParamsOutputDTOBase { }

    [FunctionOutput]
    public class GameboardParamsOutputDTOBase : IFunctionOutputDTO 
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
    }

    public partial class GetBoardOutputDTO : GetBoardOutputDTOBase { }

    [FunctionOutput]
    public class GetBoardOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual GameboardParams ReturnValue1 { get; set; }
        [Parameter("tuple", "", 2)]
        public virtual GameboardData ReturnValue2 { get; set; }
    }


}

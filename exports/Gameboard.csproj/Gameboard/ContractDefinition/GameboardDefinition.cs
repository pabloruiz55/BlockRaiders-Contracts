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
        public static string BYTECODE = "0x6080604052346100c3576103456080813803918261001c816100c8565b9384928339810103126100c35761003360806100c8565b9065ffffffff000061004482610103565b9283815261ff00606061005960208601610103565b9283602082015261007d8261007060408901610111565b9788604085015201610111565b918291015260ff69ffffffff0000000000006000549260301b1696169060018060501b031916179160081b16179160101b16171760005560405161022290816101238239f35b600080fd5b6040519190601f01601f191682016001600160401b038111838210176100ed57604052565b634e487b7160e01b600052604160045260246000fd5b519060ff821682036100c357565b519063ffffffff821682036100c35756fe60806040818152600436101561001457600080fd5b600091823560e01c9081632470df1214610119575080633264a34b1461008c57638a8c2bf51461004357600080fd5b34610088578160031936011261008857608091549080519160ff8116835260ff8160081c16602084015263ffffffff91828260101c169084015260301c166060820152f35b5080fd5b503461008857816003193601126100885790606060809282826100ae866101b0565b828152826020820152828482015201526100c7846101b0565b92549060ff8216938481526020810160ff8460081c16815260ff8383019163ffffffff80978195828960101c168652019660301c16865284519788525116602087015251169084015251166060820152f35b8390346100885760803660031901126100885760043560ff81168091036101ac578254906024359060ff821682036101a8576044359163ffffffff80841684036101a45760643590811681036101a45765ffffffff00009269ffffffff00000000000061ff009260301b169569ffffffffffffffffffff1916179160081b16179160101b1617178255f35b8680fd5b8480fd5b8280fd5b6040519190601f01601f1916820167ffffffffffffffff8111838210176101d657604052565b634e487b7160e01b600052604160045260246000fdfea26469706673582212207f512f6692335c69d8377797c8764c9c43d723818d3dfd5b1116faf2f19182f064736f6c63430008100033";
        public GameboardDeploymentBase() : base(BYTECODE) { }
        public GameboardDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("tuple", "gameboardParams_", 1)]
        public virtual GameboardParams Gameboardparams { get; set; }
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
    }

    public partial class GetBoardOutputDTO : GetBoardOutputDTOBase { }

    [FunctionOutput]
    public class GetBoardOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual GameboardParams ReturnValue1 { get; set; }
    }


}

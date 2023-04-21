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
        public static string BYTECODE = "0x60806040523461012957610d0e60e0813803918261001c8161012e565b9384928339810103126101295761003360e061012e565b61003c82610169565b80825261004b60208401610169565b9182602082015261005e60408501610177565b9081604082015261007160608601610177565b6060820181905260808601519092906001600160a01b03811681036101295760c09561ff00828565ffffffff000094608069ffffffff0000000000009801528960a08c01519b8c60a08401520151998a91015260ff600054916a0100000000000000000000600160f01b039060501b1698169061ffff60f01b16179160081b16179160101b16179160301b1617176000558160015560025560ff1960a3541660a3554260a45560a555604051610b8590816101898239f35b600080fd5b6040519190601f01601f191682016001600160401b0381118382101761015357604052565b634e487b7160e01b600052604160045260246000fd5b519060ff8216820361012957565b519063ffffffff821682036101295756fe6040608081526004908136101561001557600080fd5b6000803560e01c80632c725335146107df5780632de3a6ec146107755780633264a34b146105d65780635708e09f1461053c5780635b048171146104c15780636898f82b146102e957806388591583146102af5780638a8c2bf5146102425780639ae1579e146101cd578063bc545c31146101085763ee038beb1461009957600080fd5b346101055781600319360112610105578235908083516100ba6020826108c7565b52600a8210156100f257506020926100d991602435911b600301610b29565b50908051916100e884846108c7565b5480925251908152f35b634e487b7160e01b815260328452602490fd5b80fd5b5091346101c95760e03660031901126101c9573560ff81168091036101c95782549060243560ff811681036101c55760443563ffffffff9283821682036101c15760643593841684036101c157608435926001600160a01b03841684036101bd5761ff0065ffffffff00009269ffffffff00000000000095600160501b600160f01b039060501b169761ffff60f01b16179160081b16179160101b16179160301b161717825560a43560015560c43560025551f35b8780fd5b8680fd5b8480fd5b8280fd5b5091346101c95760603660031901126101c9578035602036604319011261023e57600a81101561022b576102099060243590831b600301610b29565b9190916102195750604435905551f35b634e487b7160e01b8452839052602483fd5b634e487b7160e01b845260328252602484fd5b8380fd5b5090346102ab57816003193601126102ab5760e091546001546002549183519360ff8216855260ff8260081c16602086015263ffffffff90818360101c16908601528160301c16606085015260018060a01b039060501c16608084015260a083015260c0820152f35b5080fd5b5090346102ab57816003193601126102ab5760609060ff60a354169060a4549060a554916102df82518095610869565b6020840152820152f35b5091346101c95760208060031936011261023e57813560025481106104b15760ff60a35416600381101561049e576001811461048e5760021461047e576103f490610336600160a361088c565b6103428160a5546108a4565b60a55560018060a01b03865460501c168680875193868501906323b872dd60e01b82523360248701523060448701526064860152606485526103856084866108c7565b61038e876108ff565b9461039b8a5196876108c7565b8786527f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c656488870152519082855af13d15610476573d916103da836108ff565b926103e7895194856108c7565b83523d898785013e61091b565b80518061040057858551f35b818391810103126101c5578101518015908115036101c557610423578080858551f35b608492519162461bcd60e51b8352820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b6064820152fd5b60609161091b565b835163c5a977b160e01b81528390fd5b845163ba26162b60e01b81528490fd5b634e487b7160e01b865260218452602486fd5b83516347d8345560e11b81528390fd5b5082903461010557602090816003193601126101055782356010936104e585610a04565b50600a8210156105295790610500919592951b600301610a9e565b90519390845b8483106105135761020086f35b8380600192845151815201920192019190610506565b634e487b7160e01b835260329052602482fd5b5091346101c95760203660031901126101c95780359060025482106105c85760ff60a3541660038110156105b557600181146105a65760021461059857506105929061058a600160a361088c565b60a5546108a4565b60a55551f35b825163c5a977b160e01b8152fd5b50825163ba26162b60e01b8152fd5b634e487b7160e01b855260218252602485fd5b82516347d8345560e11b8152fd5b508290346101055780600319360112610105578060c084516105f960e0826108c7565b82815282602082015282868201528260608201528260808201528260a08201520152806060845161062b6080826108c7565b610635600a610a56565b81528260208201528286820152015282519161065260e0846108c7565b81549160ff83168452602084019460ff8460081c1686528085019363ffffffff90818160101c1686526060870191808260301c168352608088019060018060a01b03809360501c1682526001549360a08a019485526002549560c08b019687528051976106c060808a6108c7565b6106ca6003610ae9565b895260ff60a354169060208a019a600383101561076257505089528260a4549a828a019b8c5260a5549c60608b019d8e5283519e8f915160ff1682525160ff1690602001525116908c0152511660608a0152511660808801525160a08701525160c086015260e0850190519061073f91610818565b516114e0840161074e91610869565b516115008301525161152082015261154090f35b634e487b7160e01b825260219052602490fd5b5091346101c9576114003660031901126101c95736611404116101c95760039083905b600a82106107a65750505051f35b8483825b601083106107c957505050601061020060019201930191019091610798565b60016020828293358555019201920191906107aa565b5090346102ab57816003193601126102ab57611400906107ff600a610a56565b5061081661080d6003610ae9565b91518092610818565bf35b9060009182915b600a831061082d5750505050565b815184825b601082106108515750505060206102006001920192019201919061081f565b60019083515181526020809101930191019091610832565b9060038210156108765752565b634e487b7160e01b600052602160045260246000fd5b9060038110156108765760ff80198354169116179055565b919082018092116108b157565b634e487b7160e01b600052601160045260246000fd5b90601f8019910116810190811067ffffffffffffffff8211176108e957604052565b634e487b7160e01b600052604160045260246000fd5b67ffffffffffffffff81116108e957601f01601f191660200190565b9192901561097d575081511561092f575090565b3b156109385790565b60405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e74726163740000006044820152606490fd5b8251909150156109905750805190602001fd5b6040519062461bcd60e51b82528160208060048301528251908160248401526000935b8285106109d6575050604492506000838284010152601f80199101168101030190fd5b84810182015186860160440152938101938593506109b3565b67ffffffffffffffff81116108e95760051b90565b90610a0e826109ef565b6040610a1c815192836108c7565b610a2682946109ef565b91600091825b848110610a3a575050505050565b6020908251610a4983826108c7565b8581528185015201610a2c565b90610a60826109ef565b610a6d60405191826108c7565b610a7781936109ef565b9060005b828110610a8757505050565b602090610a946010610a04565b8184015201610a7b565b906040805192610ab0610200856108c7565b600090845b60108310610ac35750505050565b60018091855190602091610ad783826108c7565b85548152815201920192019190610ab5565b9060405191610afa610140846108c7565b6000835b600a8210610b0b57505050565b60106020600192610b1b86610a9e565b815201930191019091610afe565b6010821015610b39570190600090565b634e487b7160e01b600052603260045260246000fdfea264697066735822122048ed8ff24bc83107bfe48e0678018d57b63231559220b601b992febafbcfa90864736f6c63430008100033";
        public GameboardDeploymentBase() : base(BYTECODE) { }
        public GameboardDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("tuple", "gameboardParams_", 1)]
        public virtual GameboardParams Gameboardparams { get; set; }
    }

    public partial class GameboardDataFunction : GameboardDataFunctionBase { }

    [Function("gameboardData", typeof(GameboardDataOutputDTO))]
    public class GameboardDataFunctionBase : FunctionMessage
    {

    }

    public partial class GameboardParamsFunction : GameboardParamsFunctionBase { }

    [Function("gameboardParams", typeof(GameboardParamsOutputDTO))]
    public class GameboardParamsFunctionBase : FunctionMessage
    {

    }

    public partial class Get1DarrayFunction : Get1DarrayFunctionBase { }

    [Function("get1Darray", typeof(Get1DarrayOutputDTO))]
    public class Get1DarrayFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
    }

    public partial class GetAllGridsFunction : GetAllGridsFunctionBase { }

    [Function("getAllGrids", typeof(GetAllGridsOutputDTO))]
    public class GetAllGridsFunctionBase : FunctionMessage
    {

    }

    public partial class GetBoardFunction : GetBoardFunctionBase { }

    [Function("getBoard", typeof(GetBoardOutputDTO))]
    public class GetBoardFunctionBase : FunctionMessage
    {

    }

    public partial class GetGridFunction : GetGridFunctionBase { }

    [Function("getGrid", typeof(GetGridOutputDTO))]
    public class GetGridFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 2)]
        public virtual BigInteger Y { get; set; }
    }

    public partial class PlayFunction : PlayFunctionBase { }

    [Function("play")]
    public class PlayFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "bet_", 1)]
        public virtual BigInteger Bet { get; set; }
    }

    public partial class PlayFreeFunction : PlayFreeFunctionBase { }

    [Function("playFree")]
    public class PlayFreeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "bet_", 1)]
        public virtual BigInteger Bet { get; set; }
    }

    public partial class SetAllGridsFunction : SetAllGridsFunctionBase { }

    [Function("setAllGrids")]
    public class SetAllGridsFunctionBase : FunctionMessage
    {
        [Parameter("tuple[16][10]", "gridData_", 1)]
        public virtual List<List<GridData>> Griddata { get; set; }
    }

    public partial class SetBoardFunction : SetBoardFunctionBase { }

    [Function("setBoard")]
    public class SetBoardFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "gameboardParams_", 1)]
        public virtual GameboardParams Gameboardparams { get; set; }
    }

    public partial class SetGridFunction : SetGridFunctionBase { }

    [Function("setGrid")]
    public class SetGridFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 2)]
        public virtual BigInteger Y { get; set; }
        [Parameter("tuple", "gridData_", 3)]
        public virtual GridData Griddata { get; set; }
    }







    public partial class GameboardDataOutputDTO : GameboardDataOutputDTOBase { }

    [FunctionOutput]
    public class GameboardDataOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "gameStatus", 1)]
        public virtual byte GameStatus { get; set; }
        [Parameter("uint256", "creationDate", 2)]
        public virtual BigInteger CreationDate { get; set; }
        [Parameter("uint256", "totalPool", 3)]
        public virtual BigInteger TotalPool { get; set; }
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
        [Parameter("uint256", "bet", 7)]
        public virtual BigInteger Bet { get; set; }
    }

    public partial class Get1DarrayOutputDTO : Get1DarrayOutputDTOBase { }

    [FunctionOutput]
    public class Get1DarrayOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[16]", "", 1)]
        public virtual List<GridData> ReturnValue1 { get; set; }
    }

    public partial class GetAllGridsOutputDTO : GetAllGridsOutputDTOBase { }

    [FunctionOutput]
    public class GetAllGridsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[16][10]", "", 1)]
        public virtual List<List<GridData>> ReturnValue1 { get; set; }
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

    public partial class GetGridOutputDTO : GetGridOutputDTOBase { }

    [FunctionOutput]
    public class GetGridOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual GridData ReturnValue1 { get; set; }
    }










}

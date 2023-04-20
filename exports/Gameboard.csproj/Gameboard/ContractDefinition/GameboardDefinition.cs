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
        public static string BYTECODE = "0x60806040523461012957610c8860e0813803918261001c8161012e565b9384928339810103126101295761003360e061012e565b61003c82610169565b80825261004b60208401610169565b9182602082015261005e60408501610177565b9081604082015261007160608601610177565b6060820181905260808601519092906001600160a01b03811681036101295760c09561ff00828565ffffffff000094608069ffffffff0000000000009801528960a08c01519b8c60a08401520151998a91015260ff600054916a0100000000000000000000600160f01b039060501b1698169061ffff60f01b16179160081b16179160101b16179160301b1617176000558160015560025560ff196004541660045542600555600655604051610aff90816101898239f35b600080fd5b6040519190601f01601f191682016001600160401b0381118382101761015357604052565b634e487b7160e01b600052604160045260246000fd5b519060ff8216820361012957565b519063ffffffff821682036101295756fe608080604052600436101561001357600080fd5b60003560e01c9081633264a34b146105ea575080635708e09f146105925780636898f82b146103b0578063842b4ba51461023257806388591583146101f95780638a8c2bf51461018f5780639ae1579e146101375763bc545c311461007757600080fd5b346101325760e03660031901126101325760043560ff8116809103610132576000549060243560ff811681036101325760443563ffffffff92838216820361013257606435938416840361013257608435926001600160a01b03841684036101325761ff0065ffffffff00009269ffffffff00000000000095600160501b600160f01b039060501b169761ffff60f01b16179160081b16179160101b16179160301b16171760005560a43560015560c4356002556000604051f35b600080fd5b346101325760603660031901126101325760203660431901126101325761016e6101646004356003610a58565b5060243590610a58565b610179576044359055005b634e487b7160e01b600052600060045260246000fd5b346101325760003660031901126101325760e0600054600154600254906040519260ff8116845260ff8160081c16602085015263ffffffff808260101c1660408601528160301c16606085015260018060a01b039060501c16608084015260a083015260c0820152f35b3461013257600036600319011261013257606060ff600454166005546006549061022660405180946108d0565b60208301526040820152f35b34610132576020806003193601126101325767ffffffffffffffff60043581811161013257366023820112156101325780600401358281116101325760059360243683871b850182011161013257600160401b831161039c576003548360035580841061034e575b5080849394019060036000527fc2575a0e9e593c00f959f8c92f12db2869c3395a3b0502d05e2516446f71f85b9160009460421981360301915b8787106102dd57005b80358381121561013257820184810135908a821161013257604401818c1b3603811361013257908792916103118289610a86565b6000888152848120915b83821061033757505050506001918291019501960195936102d4565b803583558a9560019384019392909201910161031b565b6003600052837fc2575a0e9e593c00f959f8c92f12db2869c3395a3b0502d05e2516446f71f85b91820191015b818110610388575061029a565b806103966000600193610a86565b0161037b565b634e487b7160e01b60009081526041600452fd5b34610132576020806003193601126101325760043560025481106105805760ff60045416600381101561056a576001811461055857600214610546576104c0906103fc600160046108dd565b610408816006546108f5565b60065560018060a01b0360005460501c1660008060405193868501906323b872dd60e01b825233602487015230604487015260648601526064855261044e608486610918565b61045787610950565b946104656040519687610918565b8786527f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c656488870152519082855af13d1561053e573d916104a483610950565b926104b26040519485610918565b83523d60008785013e61096c565b8051806104c957005b8183918101031261013257810151801590811503610132576104e757005b6084906040519062461bcd60e51b82526004820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b6064820152fd5b60609161096c565b60405163c5a977b160e01b8152600490fd5b60405163ba26162b60e01b8152600490fd5b634e487b7160e01b600052602160045260246000fd5b6040516347d8345560e11b8152600490fd5b346101325760203660031901126101325760043560025481106105805760ff60045416600381101561056a576001811461055857600214610546576105e5906105dd600160046108dd565b6006546108f5565b600655005b346101325760003660031901126101325760c08161060b60e0600094610918565b8281528260208201528260408201528260608201528260808201528260a0820152015260006060604051610640608082610918565b818152826020820152826040820152015260405161065f60e082610918565b60005460ff8116825260ff8160081c16602083015263ffffffff8160101c16604083015263ffffffff8160301c16606083015260018060a01b039060501c16608082015260015460a082015260025460c0820152604051906106c2608083610918565b6003546106ce81610a40565b906106dc6040519283610918565b8082526020820160036000527fc2575a0e9e593c00f959f8c92f12db2869c3395a3b0502d05e2516446f71f85b6000915b83831061085c5750505050825260ff60045416600381101561056a5760208301526005546040830152600654606083015260c06040519160ff815116835260ff602082015116602084015263ffffffff604082015116604084015263ffffffff606082015116606084015260018060a01b03608082015116608084015260a081015160a0840152015160c08201526101008060e0830152610180820192608081519284015281518094526101a06020818501918660051b8601019301906000905b868210610805578580866060876107ee60208201516101208601906108d0565b604081015161014085015201516101608301520390f35b90919361019f19868203018252845190602080835192838152019201906000905b8082106108435750505060208060019296019201920190916107ce565b9091926020806001928651518152019401920190610826565b815461086781610a40565b906108756040519283610918565b80825260208201846000526020600020906000905b8382106108ab5750505050602082600193928493520192019201919061070d565b6001602081926040516108be8382610918565b8654815281520193019101909161088a565b90600382101561056a5752565b90600381101561056a5760ff80198354169116179055565b9190820180921161090257565b634e487b7160e01b600052601160045260246000fd5b90601f8019910116810190811067ffffffffffffffff82111761093a57604052565b634e487b7160e01b600052604160045260246000fd5b67ffffffffffffffff811161093a57601f01601f191660200190565b919290156109ce5750815115610980575090565b3b156109895790565b60405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e74726163740000006044820152606490fd5b8251909150156109e15750805190602001fd5b6040519062461bcd60e51b82528160208060048301528251908160248401526000935b828510610a27575050604492506000838284010152601f80199101168101030190fd5b8481018201518686016044015293810193859350610a04565b67ffffffffffffffff811161093a5760051b60200190565b8054821015610a705760005260206000200190600090565b634e487b7160e01b600052603260045260246000fd5b600160401b821161093a57805491808255828110610aa357505050565b60009182526020822092830192015b828110610abe57505050565b818155600101610ab256fea26469706673582212206ff1cadd111fa3552d458278db0cd5c8161c973b1cafe99ee8cc417a65492eae64736f6c63430008100033";
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

    public partial class GetBoardFunction : GetBoardFunctionBase { }

    [Function("getBoard", typeof(GetBoardOutputDTO))]
    public class GetBoardFunctionBase : FunctionMessage
    {

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
        [Parameter("tuple[][]", "gridData_", 1)]
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

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
        public static string BYTECODE = "0x60806040523461012957610ca260e0813803918261001c8161012e565b9384928339810103126101295761003360e061012e565b61003c82610169565b80825261004b60208401610169565b9182602082015261005e60408501610177565b9081604082015261007160608601610177565b6060820181905260808601519092906001600160a01b03811681036101295760c09561ff00828565ffffffff000094608069ffffffff0000000000009801528960a08c01519b8c60a08401520151998a91015260ff600054916a0100000000000000000000600160f01b039060501b1698169061ffff60f01b16179160081b16179160101b16179160301b1617176000558160015560025560ff1960a3541660a3554260a45560a555604051610b1990816101898239f35b600080fd5b6040519190601f01601f191682016001600160401b0381118382101761015357604052565b634e487b7160e01b600052604160045260246000fd5b519060ff8216820361012957565b519063ffffffff821682036101295756fe6040608081526004908136101561001557600080fd5b6000803560e01c80632c725335146107ce5780633264a34b1461062f5780635708e09f146105955780635b048171146105165780635bb7c89d146104965780636898f82b146102ba57806388591583146102805780638a8c2bf5146102135780639aa05786146101b3578063bc545c31146100ee5763ee038beb1461009957600080fd5b346100eb57816003193601126100eb57823590600a8210156100d857506020926100ca91602435911b600301610abd565b90549060031b1c9051908152f35b634e487b7160e01b815260328452602490fd5b80fd5b5091346101af5760e03660031901126101af573560ff81168091036101af5782549060243560ff811681036101ab5760443563ffffffff9283821682036101a75760643593841684036101a757608435926001600160a01b03841684036101a35761ff0065ffffffff00009269ffffffff00000000000095600160501b600160f01b039060501b169761ffff60f01b16179160081b16179160101b16179160301b161717825560a43560015560c43560025551f35b8780fd5b8680fd5b8480fd5b8280fd5b5091346101af5760603660031901126101af578035600a81101561020057906101e391602435911b600301610abd565b81549060031b90600019821b8092604435901b1691191617905551f35b634e487b7160e01b845260328252602484fd5b50903461027c578160031936011261027c5760e091546001546002549183519360ff8216855260ff8260081c16602086015263ffffffff90818360101c16908601528160301c16606085015260018060a01b039060501c16608084015260a083015260c0820152f35b5080fd5b50903461027c578160031936011261027c5760609060ff60a354169060a4549060a554916102b082518095610857565b6020840152820152f35b5091346101af5760208060031936011261049257813560025481106104825760ff60a35416600381101561046f576001811461045f5760021461044f576103c590610307600160a361087a565b6103138160a554610892565b60a55560018060a01b03865460501c168680875193868501906323b872dd60e01b82523360248701523060448701526064860152606485526103566084866108b5565b61035f876108ed565b9461036c8a5196876108b5565b8786527f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c656488870152519082855af13d15610447573d916103ab836108ed565b926103b8895194856108b5565b83523d898785013e610909565b8051806103d157858551f35b818391810103126101ab578101518015908115036101ab576103f4578080858551f35b608492519162461bcd60e51b8352820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b6064820152fd5b606091610909565b835163c5a977b160e01b81528390fd5b845163ba26162b60e01b81528490fd5b634e487b7160e01b865260218452602486fd5b83516347d8345560e11b81528390fd5b8380fd5b5091346101af57610c803660031901126101af5736610c84116101af57600383915b600a808410156105115760108301928181015b84811061050657508290875b8381106104f2575050506001939093019250610140016104b8565b6001906020843594019381840155016104d7565b8781556001016104cb565b858551f35b50903461027c576020806003193601126101af5783358251946102008661053e8280996108b5565b369037600a821015610582579061055b919493941b600301610a45565b92519291835b6010821061056d578585f35b82806001928651815201940191019092610561565b634e487b7160e01b855260329052602484fd5b5091346101af5760203660031901126101af5780359060025482106106215760ff60a35416600381101561060e57600181146105ff576002146105f157506105eb906105e3600160a361087a565b60a554610892565b60a55551f35b825163c5a977b160e01b8152fd5b50825163ba26162b60e01b8152fd5b634e487b7160e01b855260218252602485fd5b82516347d8345560e11b8152fd5b508290346100eb57806003193601126100eb578060c0845161065260e0826108b5565b82815282602082015282868201528260608201528260808201528260a0820152015280606084516106846080826108b5565b61068e600a6109f2565b8152826020820152828682015201528251916106ab60e0846108b5565b81549160ff83168452602084019460ff8460081c1686528085019363ffffffff90818160101c1686526060870191808260301c168352608088019060018060a01b03809360501c1682526001549360a08a019485526002549560c08b0196875280519761071960808a6108b5565b6107236003610a7d565b895260ff60a354169060208a019a60038310156107bb57505089528260a4549a828a019b8c5260a5549c60608b019d8e5283519e8f915160ff1682525160ff1690602001525116908c0152511660608a0152511660808801525160a08701525160c086015260e0850190519061079891610807565b516114e084016107a791610857565b516115008301525161152082015261154090f35b634e487b7160e01b825260219052602490fd5b50903461027c578160031936011261027c57611400906107ee600a6109f2565b506108056107fc6003610a7d565b91518092610807565bf35b9060009182915b600a831061081c5750505050565b815184825b601082106108405750505060206102006001920192019201919061080e565b600190835181526020809101930191019091610821565b9060038210156108645752565b634e487b7160e01b600052602160045260246000fd5b9060038110156108645760ff80198354169116179055565b9190820180921161089f57565b634e487b7160e01b600052601160045260246000fd5b90601f8019910116810190811067ffffffffffffffff8211176108d757604052565b634e487b7160e01b600052604160045260246000fd5b67ffffffffffffffff81116108d757601f01601f191660200190565b9192901561096b575081511561091d575090565b3b156109265790565b60405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e74726163740000006044820152606490fd5b82519091501561097e5750805190602001fd5b6040519062461bcd60e51b82528160208060048301528251908160248401526000935b8285106109c4575050604492506000838284010152601f80199101168101030190fd5b84810182015186860160440152938101938593506109a1565b67ffffffffffffffff81116108d75760051b90565b906109fc826109dd565b604090610a0b825191826108b5565b610a1581946109dd565b9160005b838110610a265750505050565b6020908251610200610a3881836108b5565b3682378185015201610a19565b60405191906000835b60108210610a6757505050610a65610200836108b5565b565b6001602081928554815201930191019091610a4e565b9060405191610a8e610140846108b5565b6000835b600a8210610a9f57505050565b60106020600192610aaf86610a45565b815201930191019091610a92565b6010821015610acd570190600090565b634e487b7160e01b600052603260045260246000fdfea2646970667358221220ca80eb34be7ce0138d0c070076a257fe757443821ed9db1d80842f097e1b6b1864736f6c63430008100033";
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

    [Function("get1Darray", "uint256[16]")]
    public class Get1DarrayFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
    }

    public partial class GetAllGridsFunction : GetAllGridsFunctionBase { }

    [Function("getAllGrids", "uint256[16][10]")]
    public class GetAllGridsFunctionBase : FunctionMessage
    {

    }

    public partial class GetBoardFunction : GetBoardFunctionBase { }

    [Function("getBoard", typeof(GetBoardOutputDTO))]
    public class GetBoardFunctionBase : FunctionMessage
    {

    }

    public partial class GetGridFunction : GetGridFunctionBase { }

    [Function("getGrid", "uint256")]
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
        [Parameter("uint256[10][10]", "gridData_", 1)]
        public virtual List<List<BigInteger>> Griddata { get; set; }
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
        [Parameter("uint256", "gridData_", 3)]
        public virtual BigInteger Griddata { get; set; }
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
        [Parameter("uint256[16]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }

    public partial class GetAllGridsOutputDTO : GetAllGridsOutputDTOBase { }

    [FunctionOutput]
    public class GetAllGridsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[16][10]", "", 1)]
        public virtual List<List<BigInteger>> ReturnValue1 { get; set; }
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
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }










}

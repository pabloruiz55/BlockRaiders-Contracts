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
        public static string BYTECODE = "0x60806040523461012957610c9860e0813803918261001c8161012e565b9384928339810103126101295761003360e061012e565b61003c82610169565b80825261004b60208401610169565b9182602082015261005e60408501610177565b9081604082015261007160608601610177565b6060820181905260808601519092906001600160a01b03811681036101295760c09561ff00828565ffffffff000094608069ffffffff0000000000009801528960a08c01519b8c60a08401520151998a91015260ff600054916a0100000000000000000000600160f01b039060501b1698169061ffff60f01b16179160081b16179160101b16179160301b1617176000558160015560025560ff196067541660675542606855606955604051610b0f90816101898239f35b600080fd5b6040519190601f01601f191682016001600160401b0381118382101761015357604052565b634e487b7160e01b600052604160045260246000fd5b519060ff8216820361012957565b519063ffffffff821682036101295756fe6040608081526004908136101561001557600080fd5b6000803560e01c80632c725335146107bb5780633264a34b1461061c5780635708e09f146105825780635b048171146105005780635bb7c89d146104995780636898f82b146102bd57806388591583146102835780638a8c2bf5146102165780639aa05786146101b3578063bc545c31146100ee5763ee038beb1461009957600080fd5b346100eb57816003193601126100eb57823592600a8410156100d8576020836100ca6024356003600a890201610ab3565b90549060031b1c9051908152f35b634e487b7160e01b825260329052602490fd5b80fd5b5091346101af5760e03660031901126101af573560ff81168091036101af5782549060243560ff811681036101ab5760443563ffffffff9283821682036101a75760643593841684036101a757608435926001600160a01b03841684036101a35761ff0065ffffffff00009269ffffffff00000000000095600160501b600160f01b039060501b169761ffff60f01b16179160081b16179160101b16179160301b161717825560a43560015560c43560025551f35b8780fd5b8680fd5b8480fd5b8280fd5b5091346101af5760603660031901126101af57803590600a82101561020357506101e690600a6024359102600301610ab3565b81549060031b90600019821b8092604435901b1691191617905551f35b634e487b7160e01b845260329052602483fd5b50903461027f578160031936011261027f5760e091546001546002549183519360ff8216855260ff8260081c16602086015263ffffffff90818360101c16908601528160301c16606085015260018060a01b039060501c16608084015260a083015260c0820152f35b5080fd5b50903461027f578160031936011261027f5760609060ff606754169060685490606954916102b382518095610848565b6020840152820152f35b5091346101af5760208060031936011261049557813560025481106104855760ff606754166003811015610472576001811461046257600214610452576103c89061030a6001606761086b565b61031681606954610883565b60695560018060a01b03865460501c168680875193868501906323b872dd60e01b82523360248701523060448701526064860152606485526103596084866108a6565b610362876108de565b9461036f8a5196876108a6565b8786527f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c656488870152519082855af13d1561044a573d916103ae836108de565b926103bb895194856108a6565b83523d898785013e6108fa565b8051806103d457858551f35b818391810103126101ab578101518015908115036101ab576103f7578080858551f35b608492519162461bcd60e51b8352820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b6064820152fd5b6060916108fa565b835163c5a977b160e01b81528390fd5b845163ba26162b60e01b81528490fd5b634e487b7160e01b865260218452602486fd5b83516347d8345560e11b81528390fd5b8380fd5b5091346101af57610c803660031901126101af5736610c84116101af579060039183905b600a90818310156104fb5780865b8381106104e757505090610140600192019401910190926104bd565b6001906020833593019281890155016104cb565b858451f35b5091346101af5760208060031936011261049557813593835194610140866105298280996108a6565b369037600a938482101561056f5750836105499195929502600301610a36565b90519390845b84831061055a578686f35b8380600192845181520192019201919061054f565b634e487b7160e01b835260329052602482fd5b5091346101af5760203660031901126101af57803590600254821061060e5760ff6067541660038110156105fb57600181146105ec576002146105de57506105d8906105d06001606761086b565b606954610883565b60695551f35b825163c5a977b160e01b8152fd5b50825163ba26162b60e01b8152fd5b634e487b7160e01b855260218252602485fd5b82516347d8345560e11b8152fd5b508290346100eb57806003193601126100eb578060c0845161063f60e0826108a6565b82815282602082015282868201528260608201528260808201528260a0820152015280606084516106716080826108a6565b61067b600a6109e3565b81528260208201528286820152015282519161069860e0846108a6565b81549160ff83168452602084019460ff8460081c1686528085019363ffffffff90818160101c1686526060870191808260301c168352608088019060018060a01b03809360501c1682526001549360a08a019485526002549560c08b0196875280519761070660808a6108a6565b6107106003610a6e565b895260ff606754169060208a019a60038310156107a85750508952826068549a828a019b8c526069549c60608b019d8e5283519e8f915160ff1682525160ff1690602001525116908c0152511660608a0152511660808801525160a08701525160c086015260e08501905190610785916107f4565b51610d60840161079491610848565b51610d8083015251610da0820152610dc090f35b634e487b7160e01b825260219052602490fd5b50903461027f578160031936011261027f57610c80906107db600a6109e3565b506107f26107e96003610a6e565b915180926107f4565bf35b9060009182915b600a808410156108415782518590835b83831061082a57505050506020610140600192019201920191906107fb565b60019082518152602080910192019201919061080b565b5050505050565b9060038210156108555752565b634e487b7160e01b600052602160045260246000fd5b9060038110156108555760ff80198354169116179055565b9190820180921161089057565b634e487b7160e01b600052601160045260246000fd5b90601f8019910116810190811067ffffffffffffffff8211176108c857604052565b634e487b7160e01b600052604160045260246000fd5b67ffffffffffffffff81116108c857601f01601f191660200190565b9192901561095c575081511561090e575090565b3b156109175790565b60405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e74726163740000006044820152606490fd5b82519091501561096f5750805190602001fd5b6040519062461bcd60e51b82528160208060048301528251908160248401526000935b8285106109b5575050604492506000838284010152601f80199101168101030190fd5b8481018201518686016044015293810193859350610992565b67ffffffffffffffff81116108c85760051b90565b906109ed826109ce565b6040906109fc825191826108a6565b610a0681946109ce565b9160005b838110610a175750505050565b6020908251610140610a2981836108a6565b3682378185015201610a0a565b60405191906000835b600a8210610a5857505050610a56610140836108a6565b565b6001602081928554815201930191019091610a3f565b9060405190610a7f610140836108a6565b6000825b600a9081831015610aab57906020600192610a9d88610a36565b815201950191019093610a83565b505050909150565b600a821015610ac3570190600090565b634e487b7160e01b600052603260045260246000fdfea2646970667358221220809b9de18a2165b8086deca928ca358ab40fa10a3f1c0a29232d563bfb3c46ba64736f6c63430008100033";
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

    [Function("get1Darray", "uint256[10]")]
    public class Get1DarrayFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
    }

    public partial class GetAllGridsFunction : GetAllGridsFunctionBase { }

    [Function("getAllGrids", "uint256[10][10]")]
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
        [Parameter("uint256[10]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }

    public partial class GetAllGridsOutputDTO : GetAllGridsOutputDTOBase { }

    [FunctionOutput]
    public class GetAllGridsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[10][10]", "", 1)]
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

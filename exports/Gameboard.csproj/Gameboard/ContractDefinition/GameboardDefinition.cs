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
        public static string BYTECODE = "0x60806040523461012957610c5c60e0813803918261001c8161012e565b9384928339810103126101295761003360e061012e565b61003c82610169565b80825261004b60208401610169565b9182602082015261005e60408501610177565b9081604082015261007160608601610177565b6060820181905260808601519092906001600160a01b03811681036101295760c09561ff00828565ffffffff000094608069ffffffff0000000000009801528960a08c01519b8c60a08401520151998a91015260ff600054916a0100000000000000000000600160f01b039060501b1698169061ffff60f01b16179160081b16179160101b16179160301b1617176000558160015560025560ff1960a3541660a3554260a45560a555604051610ad390816101898239f35b600080fd5b6040519190601f01601f191682016001600160401b0381118382101761015357604052565b634e487b7160e01b600052604160045260246000fd5b519060ff8216820361012957565b519063ffffffff821682036101295756fe6040608081526004908136101561001557600080fd5b6000803560e01c80632c7253351461075a5780633264a34b146105bb5780635708e09f146105215780636807da35146104b75780636898f82b146102df57806388591583146102a55780638a8c2bf5146102385780639ae1579e146101c2578063bc545c31146100fd5763ee038beb1461008e57600080fd5b346100fa57816003193601126100fa578235928183516100af602082610842565b5260108410156100e7576020836100ce6024356003600a890201610a77565b50908051916100dd8484610842565b5480925251908152f35b634e487b7160e01b825260329052602490fd5b80fd5b5091346101be5760e03660031901126101be573560ff81168091036101be5782549060243560ff811681036101ba5760443563ffffffff9283821682036101b65760643593841684036101b657608435926001600160a01b03841684036101b25761ff0065ffffffff00009269ffffffff00000000000095600160501b600160f01b039060501b169761ffff60f01b16179160081b16179160101b16179160301b161717825560a43560015560c43560025551f35b8780fd5b8680fd5b8480fd5b8280fd5b5091346101be5760603660031901126101be5780356020366043190112610234576010811015610221576101ff90600a6024359102600301610a77565b91909161020f5750604435905551f35b634e487b7160e01b8452839052602483fd5b634e487b7160e01b845260328252602484fd5b8380fd5b5090346102a157816003193601126102a15760e091546001546002549183519360ff8216855260ff8260081c16602086015263ffffffff90818360101c16908601528160301c16606085015260018060a01b039060501c16608084015260a083015260c0820152f35b5080fd5b5090346102a157816003193601126102a15760609060ff60a354169060a4549060a554916102d5825180956107e4565b6020840152820152f35b5091346101be5760208060031936011261023457813560025481106104a75760ff60a354166003811015610494576001811461048457600214610474576103ea9061032c600160a3610807565b6103388160a55461081f565b60a55560018060a01b03865460501c168680875193868501906323b872dd60e01b825233602487015230604487015260648601526064855261037b608486610842565b6103848761087a565b946103918a519687610842565b8786527f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c656488870152519082855af13d1561046c573d916103d08361087a565b926103dd89519485610842565b83523d898785013e610896565b8051806103f657858551f35b818391810103126101ba578101518015908115036101ba57610419578080858551f35b608492519162461bcd60e51b8352820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b6064820152fd5b606091610896565b835163c5a977b160e01b81528390fd5b845163ba26162b60e01b81528490fd5b634e487b7160e01b865260218452602486fd5b83516347d8345560e11b81528390fd5b5091346101be576114003660031901126101be5736611404116101be5760039083905b601082106104e85750505051f35b8483825b600a831061050b57505050600a610140600192019301910190916104da565b60016020828293358555019201920191906104ec565b5091346101be5760203660031901126101be5780359060025482106105ad5760ff60a35416600381101561059a576001811461058b5760021461057d57506105779061056f600160a3610807565b60a55461081f565b60a55551f35b825163c5a977b160e01b8152fd5b50825163ba26162b60e01b8152fd5b634e487b7160e01b855260218252602485fd5b82516347d8345560e11b8152fd5b508290346100fa57806003193601126100fa578060c084516105de60e082610842565b82815282602082015282868201528260608201528260808201528260a082015201528060608451610610608082610842565b61061a601061097f565b81528260208201528286820152015282519161063760e084610842565b81549160ff83168452602084019460ff8460081c1686528085019363ffffffff90818160101c1686526060870191808260301c168352608088019060018060a01b03809360501c1682526001549360a08a019485526002549560c08b019687528051976106a560808a610842565b6106af60036109f7565b895260ff60a354169060208a019a600383101561074757505089528260a4549a828a019b8c5260a5549c60608b019d8e5283519e8f915160ff1682525160ff1690602001525116908c0152511660608a0152511660808801525160a08701525160c086015260e0850190519061072491610793565b516114e08401610733916107e4565b516115008301525161152082015261154090f35b634e487b7160e01b825260219052602490fd5b5090346102a157816003193601126102a1576114009061077a601061097f565b5061079161078860036109f7565b91518092610793565bf35b9060009182915b601083106107a85750505050565b815184825b600a82106107cc5750505060206101406001920192019201919061079a565b600190835151815260208091019301910190916107ad565b9060038210156107f15752565b634e487b7160e01b600052602160045260246000fd5b9060038110156107f15760ff80198354169116179055565b9190820180921161082c57565b634e487b7160e01b600052601160045260246000fd5b90601f8019910116810190811067ffffffffffffffff82111761086457604052565b634e487b7160e01b600052604160045260246000fd5b67ffffffffffffffff811161086457601f01601f191660200190565b919290156108f857508151156108aa575090565b3b156108b35790565b60405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e74726163740000006044820152606490fd5b82519091501561090b5750805190602001fd5b6040519062461bcd60e51b82528160208060048301528251908160248401526000935b828510610951575050604492506000838284010152601f80199101168101030190fd5b848101820151868601604401529381019385935061092e565b67ffffffffffffffff81116108645760051b90565b906109898261096a565b604061099781519283610842565b6109a1829461096a565b91600091825b8481106109b5575050505050565b81516101406109c48183610842565b855b8181106109db575050838201526020016109a7565b60209085516109ea8382610842565b88815281850152016109c6565b906040805192610a0961020085610842565b60009081855b60108410610a1e575050505050565b8451610a2c61014082610842565b8383825b600a8210610a5157505050602082600a926001945201930193019291610a0f565b600180918a5190602091610a658382610842565b86548152815201930191019091610a30565b600a821015610a87570190600090565b634e487b7160e01b600052603260045260246000fdfea26469706673582212205acf6734d477df49329fda97daed84e0cdcca5263f6cfef5c1e7c48958e949cb64736f6c63430008100033";
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
        [Parameter("tuple[10][16]", "gridData_", 1)]
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

    public partial class GetAllGridsOutputDTO : GetAllGridsOutputDTOBase { }

    [FunctionOutput]
    public class GetAllGridsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[10][16]", "", 1)]
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

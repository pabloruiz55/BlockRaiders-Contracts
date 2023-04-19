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

namespace GameboardFactory.GameboardFactory.ContractDefinition
{


    public partial class GameboardFactoryDeployment : GameboardFactoryDeploymentBase
    {
        public GameboardFactoryDeployment() : base(BYTECODE) { }
        public GameboardFactoryDeployment(string byteCode) : base(byteCode) { }
    }

    public class GameboardFactoryDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608080604052346100165761083f908161001c8239f35b600080fdfe6080604081815260048036101561001557600080fd5b600092833560e01c9081635f5fb968146102b5575080636fd2212a146102955780637fefc92014610278578063973b065e1461009b5763a3126b2b1461005a57600080fd5b346100975760203660031901126100975735825481101561009757610081906020936103b9565b905491519160018060a01b039160031b1c168152f35b8280fd5b508290346102745781600319360112610274578154825b818110610165578385805190808201908083526060918251809152828401916080918290875b81811061014657505050602091858403838701528285519485815201948197925b8584106101065787870388f35b8851805160ff90811689528187015116888701528082015163ffffffff9081168984015290830151168783015297840197958201956001909301926100f9565b82516001600160a01b03168652602095860195909201916001016100d8565b61016f81856103b9565b90546060916001600160a01b0391600391821b1c821661018f8585610459565b5261019a84886103b9565b9054911b1c1686518091633264a34b60e01b8252818760809384935afa91821561026a5787926101e7575b505082826101e0926101da8360019796610459565b52610459565b50016100b2565b9080925081813d8311610263575b6101ff818361046d565b8101031261025f5792826101e09261025283956001976102218d51948561046d565b61022a816104a5565b845260206102398183016104a5565b908501526102488d82016104b3565b8d850152016104b3565b82820152925092936101c5565b8680fd5b503d6101f5565b88513d89823e3d90fd5b5080fd5b505034610274578160031936011261027457602091549051908152f35b5034610097576020366003190112610097576020926100819135906103b9565b9050346103b55760803660031901126103b5576103458082019082821067ffffffffffffffff8311176103a25760809183916104c583396102f6818661040b565b03019084f08015610396578354680100000000000000008110156103835780600161032492018655856103b9565b819291549060031b9160018060a01b039283811b93849216901b1691191617905561035a8354918351928352602083019061040b565b7fa9e95f44a6a958c1e2354513c074823adbeb3a376f72ff2ab4f001d9ac945f5560a03392a251f35b634e487b7160e01b855260418352602485fd5b505051903d90823e3d90fd5b634e487b7160e01b865260418452602486fd5b8380fd5b80548210156103d15760005260206000200190600090565b634e487b7160e01b600052603260045260246000fd5b359060ff821682036103f557565b600080fd5b359063ffffffff821682036103f557565b60609060ff610419826103e7565b16835260ff61042a602083016103e7565b1660208401526104538263ffffffff9283610447604083016103fa565b166040870152016103fa565b16910152565b80518210156103d15760209160051b010190565b90601f8019910116810190811067ffffffffffffffff82111761048f57604052565b634e487b7160e01b600052604160045260246000fd5b519060ff821682036103f557565b519063ffffffff821682036103f55756fe6080604052346100c3576103456080813803918261001c816100c8565b9384928339810103126100c35761003360806100c8565b9065ffffffff000061004482610103565b9283815261ff00606061005960208601610103565b9283602082015261007d8261007060408901610111565b9788604085015201610111565b918291015260ff69ffffffff0000000000006000549260301b1696169060018060501b031916179160081b16179160101b16171760005560405161022290816101238239f35b600080fd5b6040519190601f01601f191682016001600160401b038111838210176100ed57604052565b634e487b7160e01b600052604160045260246000fd5b519060ff821682036100c357565b519063ffffffff821682036100c35756fe60806040818152600436101561001457600080fd5b600091823560e01c9081632470df1214610119575080633264a34b1461008c57638a8c2bf51461004357600080fd5b34610088578160031936011261008857608091549080519160ff8116835260ff8160081c16602084015263ffffffff91828260101c169084015260301c166060820152f35b5080fd5b503461008857816003193601126100885790606060809282826100ae866101b0565b828152826020820152828482015201526100c7846101b0565b92549060ff8216938481526020810160ff8460081c16815260ff8383019163ffffffff80978195828960101c168652019660301c16865284519788525116602087015251169084015251166060820152f35b8390346100885760803660031901126100885760043560ff81168091036101ac578254906024359060ff821682036101a8576044359163ffffffff80841684036101a45760643590811681036101a45765ffffffff00009269ffffffff00000000000061ff009260301b169569ffffffffffffffffffff1916179160081b16179160101b1617178255f35b8680fd5b8480fd5b8280fd5b6040519190601f01601f1916820167ffffffffffffffff8111838210176101d657604052565b634e487b7160e01b600052604160045260246000fdfea26469706673582212207f512f6692335c69d8377797c8764c9c43d723818d3dfd5b1116faf2f19182f064736f6c63430008100033a2646970667358221220242026122dc64b5e70efdfb35a3ad3eaff4b28e90de78c6ec4537e91bfa7f24064736f6c63430008100033";
        public GameboardFactoryDeploymentBase() : base(BYTECODE) { }
        public GameboardFactoryDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CreateGameboardFunction : CreateGameboardFunctionBase { }

    [Function("createGameboard")]
    public class CreateGameboardFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "gameboardParams_", 1)]
        public virtual GameboardParams Gameboardparams { get; set; }
    }

    public partial class GameboardsFunction : GameboardsFunctionBase { }

    [Function("gameboards", "address")]
    public class GameboardsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetAllGameboardsFunction : GetAllGameboardsFunctionBase { }

    [Function("getAllGameboards", typeof(GetAllGameboardsOutputDTO))]
    public class GetAllGameboardsFunctionBase : FunctionMessage
    {

    }

    public partial class GetGameboardFunction : GetGameboardFunctionBase { }

    [Function("getGameboard", "address")]
    public class GetGameboardFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id_", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class GetGameboardsLengthFunction : GetGameboardsLengthFunctionBase { }

    [Function("getGameboardsLength", "uint256")]
    public class GetGameboardsLengthFunctionBase : FunctionMessage
    {

    }

    public partial class NewGameboardEventDTO : NewGameboardEventDTOBase { }

    [Event("NewGameboard")]
    public class NewGameboardEventDTOBase : IEventDTO
    {
        [Parameter("address", "creator_", 1, true )]
        public virtual string Creator { get; set; }
        [Parameter("uint256", "id_", 2, false )]
        public virtual BigInteger Id { get; set; }
        [Parameter("tuple", "gameboardParams_", 3, false )]
        public virtual GameboardParams Gameboardparams { get; set; }
    }



    public partial class GameboardsOutputDTO : GameboardsOutputDTOBase { }

    [FunctionOutput]
    public class GameboardsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetAllGameboardsOutputDTO : GetAllGameboardsOutputDTOBase { }

    [FunctionOutput]
    public class GetAllGameboardsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "gameboards_", 1)]
        public virtual List<string> Gameboards { get; set; }
        [Parameter("tuple[]", "gameboardParams_", 2)]
        public virtual List<GameboardParams> Gameboardparams { get; set; }
    }

    public partial class GetGameboardOutputDTO : GetGameboardOutputDTOBase { }

    [FunctionOutput]
    public class GetGameboardOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetGameboardsLengthOutputDTO : GetGameboardsLengthOutputDTOBase { }

    [FunctionOutput]
    public class GetGameboardsLengthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}

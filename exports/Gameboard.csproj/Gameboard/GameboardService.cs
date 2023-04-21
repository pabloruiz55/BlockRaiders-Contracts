using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Gameboard.Gameboard.ContractDefinition;

namespace Gameboard.Gameboard
{
    public partial class GameboardService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, GameboardDeployment gameboardDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<GameboardDeployment>().SendRequestAndWaitForReceiptAsync(gameboardDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, GameboardDeployment gameboardDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<GameboardDeployment>().SendRequestAsync(gameboardDeployment);
        }

        public static async Task<GameboardService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, GameboardDeployment gameboardDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, gameboardDeployment, cancellationTokenSource);
            return new GameboardService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public GameboardService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<GameboardDataOutputDTO> GameboardDataQueryAsync(GameboardDataFunction gameboardDataFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GameboardDataFunction, GameboardDataOutputDTO>(gameboardDataFunction, blockParameter);
        }

        public Task<GameboardDataOutputDTO> GameboardDataQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GameboardDataFunction, GameboardDataOutputDTO>(null, blockParameter);
        }

        public Task<GameboardParamsOutputDTO> GameboardParamsQueryAsync(GameboardParamsFunction gameboardParamsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GameboardParamsFunction, GameboardParamsOutputDTO>(gameboardParamsFunction, blockParameter);
        }

        public Task<GameboardParamsOutputDTO> GameboardParamsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GameboardParamsFunction, GameboardParamsOutputDTO>(null, blockParameter);
        }

        public Task<List<BigInteger>> Get1DarrayQueryAsync(Get1DarrayFunction get1DarrayFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get1DarrayFunction, List<BigInteger>>(get1DarrayFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> Get1DarrayQueryAsync(BigInteger x, BlockParameter blockParameter = null)
        {
            var get1DarrayFunction = new Get1DarrayFunction();
                get1DarrayFunction.X = x;
            
            return ContractHandler.QueryAsync<Get1DarrayFunction, List<BigInteger>>(get1DarrayFunction, blockParameter);
        }

        public Task<List<List<BigInteger>>> GetAllGridsQueryAsync(GetAllGridsFunction getAllGridsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAllGridsFunction, List<List<BigInteger>>>(getAllGridsFunction, blockParameter);
        }

        
        public Task<List<List<BigInteger>>> GetAllGridsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAllGridsFunction, List<List<BigInteger>>>(null, blockParameter);
        }

        public Task<GetBoardOutputDTO> GetBoardQueryAsync(GetBoardFunction getBoardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBoardFunction, GetBoardOutputDTO>(getBoardFunction, blockParameter);
        }

        public Task<GetBoardOutputDTO> GetBoardQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBoardFunction, GetBoardOutputDTO>(null, blockParameter);
        }

        public Task<BigInteger> GetGridQueryAsync(GetGridFunction getGridFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGridFunction, BigInteger>(getGridFunction, blockParameter);
        }

        
        public Task<BigInteger> GetGridQueryAsync(BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var getGridFunction = new GetGridFunction();
                getGridFunction.X = x;
                getGridFunction.Y = y;
            
            return ContractHandler.QueryAsync<GetGridFunction, BigInteger>(getGridFunction, blockParameter);
        }

        public Task<string> PlayRequestAsync(PlayFunction playFunction)
        {
             return ContractHandler.SendRequestAsync(playFunction);
        }

        public Task<TransactionReceipt> PlayRequestAndWaitForReceiptAsync(PlayFunction playFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(playFunction, cancellationToken);
        }

        public Task<string> PlayRequestAsync(BigInteger bet)
        {
            var playFunction = new PlayFunction();
                playFunction.Bet = bet;
            
             return ContractHandler.SendRequestAsync(playFunction);
        }

        public Task<TransactionReceipt> PlayRequestAndWaitForReceiptAsync(BigInteger bet, CancellationTokenSource cancellationToken = null)
        {
            var playFunction = new PlayFunction();
                playFunction.Bet = bet;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(playFunction, cancellationToken);
        }

        public Task<string> PlayFreeRequestAsync(PlayFreeFunction playFreeFunction)
        {
             return ContractHandler.SendRequestAsync(playFreeFunction);
        }

        public Task<TransactionReceipt> PlayFreeRequestAndWaitForReceiptAsync(PlayFreeFunction playFreeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(playFreeFunction, cancellationToken);
        }

        public Task<string> PlayFreeRequestAsync(BigInteger bet)
        {
            var playFreeFunction = new PlayFreeFunction();
                playFreeFunction.Bet = bet;
            
             return ContractHandler.SendRequestAsync(playFreeFunction);
        }

        public Task<TransactionReceipt> PlayFreeRequestAndWaitForReceiptAsync(BigInteger bet, CancellationTokenSource cancellationToken = null)
        {
            var playFreeFunction = new PlayFreeFunction();
                playFreeFunction.Bet = bet;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(playFreeFunction, cancellationToken);
        }

        public Task<string> SetAllGridsRequestAsync(SetAllGridsFunction setAllGridsFunction)
        {
             return ContractHandler.SendRequestAsync(setAllGridsFunction);
        }

        public Task<TransactionReceipt> SetAllGridsRequestAndWaitForReceiptAsync(SetAllGridsFunction setAllGridsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAllGridsFunction, cancellationToken);
        }

        public Task<string> SetAllGridsRequestAsync(List<List<BigInteger>> griddata)
        {
            var setAllGridsFunction = new SetAllGridsFunction();
                setAllGridsFunction.Griddata = griddata;
            
             return ContractHandler.SendRequestAsync(setAllGridsFunction);
        }

        public Task<TransactionReceipt> SetAllGridsRequestAndWaitForReceiptAsync(List<List<BigInteger>> griddata, CancellationTokenSource cancellationToken = null)
        {
            var setAllGridsFunction = new SetAllGridsFunction();
                setAllGridsFunction.Griddata = griddata;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAllGridsFunction, cancellationToken);
        }

        public Task<string> SetBoardRequestAsync(SetBoardFunction setBoardFunction)
        {
             return ContractHandler.SendRequestAsync(setBoardFunction);
        }

        public Task<TransactionReceipt> SetBoardRequestAndWaitForReceiptAsync(SetBoardFunction setBoardFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBoardFunction, cancellationToken);
        }

        public Task<string> SetBoardRequestAsync(GameboardParams gameboardparams)
        {
            var setBoardFunction = new SetBoardFunction();
                setBoardFunction.Gameboardparams = gameboardparams;
            
             return ContractHandler.SendRequestAsync(setBoardFunction);
        }

        public Task<TransactionReceipt> SetBoardRequestAndWaitForReceiptAsync(GameboardParams gameboardparams, CancellationTokenSource cancellationToken = null)
        {
            var setBoardFunction = new SetBoardFunction();
                setBoardFunction.Gameboardparams = gameboardparams;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBoardFunction, cancellationToken);
        }

        public Task<string> SetGridRequestAsync(SetGridFunction setGridFunction)
        {
             return ContractHandler.SendRequestAsync(setGridFunction);
        }

        public Task<TransactionReceipt> SetGridRequestAndWaitForReceiptAsync(SetGridFunction setGridFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGridFunction, cancellationToken);
        }

        public Task<string> SetGridRequestAsync(BigInteger x, BigInteger y, BigInteger griddata)
        {
            var setGridFunction = new SetGridFunction();
                setGridFunction.X = x;
                setGridFunction.Y = y;
                setGridFunction.Griddata = griddata;
            
             return ContractHandler.SendRequestAsync(setGridFunction);
        }

        public Task<TransactionReceipt> SetGridRequestAndWaitForReceiptAsync(BigInteger x, BigInteger y, BigInteger griddata, CancellationTokenSource cancellationToken = null)
        {
            var setGridFunction = new SetGridFunction();
                setGridFunction.X = x;
                setGridFunction.Y = y;
                setGridFunction.Griddata = griddata;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGridFunction, cancellationToken);
        }
    }
}

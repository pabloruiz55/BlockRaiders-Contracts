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

        public Task<GetBoardOutputDTO> GetBoardQueryAsync(GetBoardFunction getBoardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBoardFunction, GetBoardOutputDTO>(getBoardFunction, blockParameter);
        }

        public Task<GetBoardOutputDTO> GetBoardQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBoardFunction, GetBoardOutputDTO>(null, blockParameter);
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
    }
}

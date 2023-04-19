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
using GameboardFactory.GameboardFactory.ContractDefinition;

namespace GameboardFactory.GameboardFactory
{
    public partial class GameboardFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, GameboardFactoryDeployment gameboardFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<GameboardFactoryDeployment>().SendRequestAndWaitForReceiptAsync(gameboardFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, GameboardFactoryDeployment gameboardFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<GameboardFactoryDeployment>().SendRequestAsync(gameboardFactoryDeployment);
        }

        public static async Task<GameboardFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, GameboardFactoryDeployment gameboardFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, gameboardFactoryDeployment, cancellationTokenSource);
            return new GameboardFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public GameboardFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CreateGameboardRequestAsync(CreateGameboardFunction createGameboardFunction)
        {
             return ContractHandler.SendRequestAsync(createGameboardFunction);
        }

        public Task<TransactionReceipt> CreateGameboardRequestAndWaitForReceiptAsync(CreateGameboardFunction createGameboardFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createGameboardFunction, cancellationToken);
        }

        public Task<string> CreateGameboardRequestAsync(GameboardParams gameboardparams)
        {
            var createGameboardFunction = new CreateGameboardFunction();
                createGameboardFunction.Gameboardparams = gameboardparams;
            
             return ContractHandler.SendRequestAsync(createGameboardFunction);
        }

        public Task<TransactionReceipt> CreateGameboardRequestAndWaitForReceiptAsync(GameboardParams gameboardparams, CancellationTokenSource cancellationToken = null)
        {
            var createGameboardFunction = new CreateGameboardFunction();
                createGameboardFunction.Gameboardparams = gameboardparams;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createGameboardFunction, cancellationToken);
        }

        public Task<string> GameboardsQueryAsync(GameboardsFunction gameboardsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GameboardsFunction, string>(gameboardsFunction, blockParameter);
        }

        
        public Task<string> GameboardsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var gameboardsFunction = new GameboardsFunction();
                gameboardsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<GameboardsFunction, string>(gameboardsFunction, blockParameter);
        }

        public Task<GetAllBoardsOutputDTO> GetAllBoardsQueryAsync(GetAllBoardsFunction getAllBoardsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllBoardsFunction, GetAllBoardsOutputDTO>(getAllBoardsFunction, blockParameter);
        }

        public Task<GetAllBoardsOutputDTO> GetAllBoardsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllBoardsFunction, GetAllBoardsOutputDTO>(null, blockParameter);
        }

        public Task<GetBoardOutputDTO> GetBoardQueryAsync(GetBoardFunction getBoardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBoardFunction, GetBoardOutputDTO>(getBoardFunction, blockParameter);
        }

        public Task<GetBoardOutputDTO> GetBoardQueryAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var getBoardFunction = new GetBoardFunction();
                getBoardFunction.Id = id;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetBoardFunction, GetBoardOutputDTO>(getBoardFunction, blockParameter);
        }

        public Task<BigInteger> GetGameboardsLengthQueryAsync(GetGameboardsLengthFunction getGameboardsLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGameboardsLengthFunction, BigInteger>(getGameboardsLengthFunction, blockParameter);
        }

        
        public Task<BigInteger> GetGameboardsLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGameboardsLengthFunction, BigInteger>(null, blockParameter);
        }
    }
}

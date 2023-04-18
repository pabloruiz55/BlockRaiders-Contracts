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

        public Task<uint> Color1QueryAsync(Color1Function color1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Color1Function, uint>(color1Function, blockParameter);
        }

        
        public Task<uint> Color1QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Color1Function, uint>(null, blockParameter);
        }

        public Task<uint> Color2QueryAsync(Color2Function color2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Color2Function, uint>(color2Function, blockParameter);
        }

        
        public Task<uint> Color2QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Color2Function, uint>(null, blockParameter);
        }

        public Task<GetBoardOutputDTO> GetBoardQueryAsync(GetBoardFunction getBoardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBoardFunction, GetBoardOutputDTO>(getBoardFunction, blockParameter);
        }

        public Task<GetBoardOutputDTO> GetBoardQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBoardFunction, GetBoardOutputDTO>(null, blockParameter);
        }

        public Task<byte> HeightQueryAsync(HeightFunction heightFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HeightFunction, byte>(heightFunction, blockParameter);
        }

        
        public Task<byte> HeightQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HeightFunction, byte>(null, blockParameter);
        }

        public Task<string> SetBoardRequestAsync(SetBoardFunction setBoardFunction)
        {
             return ContractHandler.SendRequestAsync(setBoardFunction);
        }

        public Task<TransactionReceipt> SetBoardRequestAndWaitForReceiptAsync(SetBoardFunction setBoardFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBoardFunction, cancellationToken);
        }

        public Task<string> SetBoardRequestAsync(byte width, byte height, uint color1, uint color2)
        {
            var setBoardFunction = new SetBoardFunction();
                setBoardFunction.Width = width;
                setBoardFunction.Height = height;
                setBoardFunction.Color1 = color1;
                setBoardFunction.Color2 = color2;
            
             return ContractHandler.SendRequestAsync(setBoardFunction);
        }

        public Task<TransactionReceipt> SetBoardRequestAndWaitForReceiptAsync(byte width, byte height, uint color1, uint color2, CancellationTokenSource cancellationToken = null)
        {
            var setBoardFunction = new SetBoardFunction();
                setBoardFunction.Width = width;
                setBoardFunction.Height = height;
                setBoardFunction.Color1 = color1;
                setBoardFunction.Color2 = color2;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBoardFunction, cancellationToken);
        }

        public Task<byte> WidthQueryAsync(WidthFunction widthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WidthFunction, byte>(widthFunction, blockParameter);
        }

        
        public Task<byte> WidthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WidthFunction, byte>(null, blockParameter);
        }
    }
}

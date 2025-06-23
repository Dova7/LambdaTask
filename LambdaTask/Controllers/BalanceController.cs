using Application.Contracts.IServices.Main;
using Application.Models.Main.Dtos.Balances;
using Domain.Constants.Enums;
using LambdaTask.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LambdaTask.Controllers
{
    [Route("api/Balances")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAmountToBalance([FromBody] AddToBalanceDto addDto)
        {
            await _balanceService.AddAmountToBalanceAsync(addDto);

            var response = new APIResponse
            {
                IsSuccess = true,
                Message = "Amount added successfully.",
                StatusCode = StatusCodes.Status200OK
            };

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBalances()
        {
            var result = await _balanceService.GetAllBalancesAsync();

            var response = new APIResponse
            {
                Result = result,
                IsSuccess = true,
                Message = "Balances retrieved successfully.",
                StatusCode = StatusCodes.Status200OK
            };

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{currency}")]
        public async Task<IActionResult> GetBalanceInfo(Currency currency)
        {
            var result = await _balanceService.GetBalanceInfoAsync(currency);

            var response = new APIResponse
            {
                Result = result,
                IsSuccess = true,
                Message = $"Balance for {currency} retrieved successfully.",
                StatusCode = StatusCodes.Status200OK
            };

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> WithdrawFromBalance([FromBody] WithdrawFromBalanceDto withdrawDto)
        {
            await _balanceService.WithdrawFromBalanceAsync(withdrawDto);

            var response = new APIResponse
            {
                IsSuccess = true,
                Message = "Withdrawal successful.",
                StatusCode = StatusCodes.Status200OK
            };

            return StatusCode(response.StatusCode, response);
        }
    }
}

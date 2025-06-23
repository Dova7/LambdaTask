using Application.Models.Main.Dtos.Balances;
using Domain.Constants.Enums;

namespace Application.Contracts.IServices.Main
{
    public interface IBalanceService
    {
        Task AddAmountToBalanceAsync(AddToBalanceDto addToBalanceDto);
        Task<List<GetAllBalancesDto>> GetAllBalancesAsync();
        Task<GetBalanceInfoDto> GetBalanceInfoAsync(Currency currency);
        Task WithdrawFromBalanceAsync(WithdrawFromBalanceDto withdrawFromBalanceDto);
    }
}

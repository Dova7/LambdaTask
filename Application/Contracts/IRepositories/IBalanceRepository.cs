using Application.Contracts.Common;
using Domain.Constants.Enums;
using Domain.Entities;

namespace Application.Contracts.IRepositories
{
    public interface IBalanceRepository : IBaseRepository<Balance>, ISavable
    {
        Task<Balance> GetByIdWithLedgersAsync(Guid id);
        Task<List<Balance>> GetByUserIdAsync(Guid userId);
        Task<Balance> GetByUserIdAndCurrencyAsync(Guid userId, Currency currency);
        Task<int> GetBalanceAmountAsync(Guid balanceId);
        Task<bool> ExistsAsync(Guid userId, Currency currency);
    }
}
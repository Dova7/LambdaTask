using Application.Contracts.Common;
using Application.Contracts.IRepositories;
using Domain.Constants.Enums;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Main
{
    public class BalanceRepository : BaseRepository<Balance>, IBalanceRepository, ISavable
    {
        private readonly ApplicationDbContext _context;
        public BalanceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(Guid userId, Currency currency)
        {
            return await _context.Balances.AnyAsync(b => b.UserId == userId && b.Currency == currency);
        }

        public async Task<int> GetBalanceAmountAsync(Guid balanceId)
        {
            var result = await _context.Balances
                .Where(b => b.Id == balanceId)
                .FirstOrDefaultAsync();
            if (result == null)
            {
                throw new InvalidOperationException($"Balance with ID {balanceId} does not exist.");
            }
            return result.Amount;
        }

        public async Task<Balance> GetByIdWithLedgersAsync(Guid id)
        {
            var result = await _context.Balances
                .Include(b => b.LedgerEntries)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (result == null)
            {
                throw new InvalidOperationException($"Balance with ID {id} does not exist.");
            }
            return result;
        }

        public async Task<Balance> GetByUserIdAndCurrencyAsync(Guid userId, Currency currency)
        {
            var result = await _context.Balances
                .FirstOrDefaultAsync(b => b.UserId == userId && b.Currency == currency);
            if (result == null)
            {
                throw new InvalidOperationException($"Balance for User ID {userId} and Currency {currency} does not exist.");
            }
            return result;
        }

        public async Task<List<Balance>> GetByUserIdAsync(Guid userId)
        {
            var result = await _context.Balances
                .Where(b => b.UserId == userId)
                .ToListAsync();
            return result;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

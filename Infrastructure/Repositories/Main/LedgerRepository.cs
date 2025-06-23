using Application.Contracts.Common;
using Application.Contracts.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Main
{
    public class LedgerRepository : BaseRepository<LedgerEntry>, ILedgerRepository, ISavable
    {
        private readonly ApplicationDbContext _context;

        public LedgerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LedgerEntry>> GetByBalanceIdAsync(Guid balanceId)
        {
            var entries = await _context.LedgerEntries
                .Where(le => le.BalanceId == balanceId)
                .ToListAsync();
            return entries;
        }

        public async Task<List<LedgerEntry>> GetByGameIdAsync(Guid gameId)
        {
            var entries = await _context.LedgerEntries
                .Where(le => le.GameId == gameId)
                .ToListAsync();
            return entries;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

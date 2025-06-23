using Application.Contracts.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PostgresDistributedLock : IDistributedLock
    {
        private readonly ApplicationDbContext _context; 
        public PostgresDistributedLock(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task RunLockedAsync(long key, Func<Task> action)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            await _context.Database.ExecuteSqlRawAsync("SELECT pg_advisory_xact_lock({0});", key);

            await action();

            await transaction.CommitAsync();
        }
    }
}

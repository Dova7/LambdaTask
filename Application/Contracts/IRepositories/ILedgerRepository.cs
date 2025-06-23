using Application.Contracts.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.IRepositories
{
    public interface ILedgerRepository : IBaseRepository<LedgerEntry>, ISavable   
    {
        Task<List<LedgerEntry>> GetByBalanceIdAsync(Guid balanceId);
        Task<List<LedgerEntry>> GetByGameIdAsync(Guid gameId);
    }
}

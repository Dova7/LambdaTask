using Domain.Constants.Enums;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class LedgerEntry : BaseEntity
    {
        public int Amount { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public TransactionDescription TransactionDescription { get; set; }

        public Guid BalanceId { get; set; }
        public Balance Balance { get; set; } = null!;

        public Guid? GameId { get; set; }
        public Game? Game { get; set; }
    }
}

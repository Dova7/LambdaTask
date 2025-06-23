using Domain.Constants.Enums;
using Domain.Entities.Common;
using Domain.Entities.Identity;

namespace Domain.Entities
{
    public class Balance : BaseEntity
    {
        public int Amount { get; set; } = 0;
        public Currency Currency { get; set; } = Currency.GEL;

        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public ICollection<LedgerEntry>? LedgerEntries { get; set; }
    }
}

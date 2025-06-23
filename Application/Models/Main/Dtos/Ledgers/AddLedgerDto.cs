using Domain.Constants.Enums;

namespace Application.Models.Main.Dtos.Ledgers
{
    public class AddLedgerDto
    {
        public int Amount { get; set; }
        public TransactionDescription TransactionDescription { get; set; }
    }
}

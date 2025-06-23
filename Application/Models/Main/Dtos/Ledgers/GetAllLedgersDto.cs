using Domain.Constants.Enums;

namespace Application.Models.Main.Dtos.Ledgers
{
    public class GetAllLedgersDto
    {
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public TransactionDescription TransactionDescription { get; set; }
    }
}

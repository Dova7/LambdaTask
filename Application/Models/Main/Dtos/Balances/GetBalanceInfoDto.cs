using Domain.Constants.Enums;

namespace Application.Models.Main.Dtos.Balances
{
    public class GetBalanceInfoDto
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}

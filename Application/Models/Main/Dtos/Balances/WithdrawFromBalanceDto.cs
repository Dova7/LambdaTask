using Domain.Constants.Enums;

namespace Application.Models.Main.Dtos.Balances
{
    public class WithdrawFromBalanceDto
    {
        public Currency Currency { get; set; }
        public int Amount { get; set; }
    }
}

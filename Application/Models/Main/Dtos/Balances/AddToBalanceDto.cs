using Domain.Constants.Enums;

namespace Application.Models.Main.Dtos.Balances
{
    public class AddToBalanceDto
    {
        public Currency Currency { get; set; }
        public int Amount { get; set; }
    }
}

using Domain.Constants.Enums;

namespace Application.Models.Main.Dtos.Games
{
    public class PlayGameDto
    {
        public Guid GameId { get; set; }
        public int Amount { get; set; }
        public Currency Currency { get; set; }
    }
}

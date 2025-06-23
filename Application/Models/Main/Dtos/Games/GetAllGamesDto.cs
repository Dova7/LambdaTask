namespace Application.Models.Main.Dtos.Games
{
    public class GetAllGamesDto
    {
        public Guid Id { get; set; }
        public string GameName { get; set; } = null!;
    }
}

using Application.Models.Main.Dtos.Games;
using Domain.Constants.Enums;

namespace Application.Contracts.IServices.Main
{
    public interface IGameService
    {
        Task<GameResultDto> PlayGame(PlayGameDto playGameDto);
        Task<List<GetAllGamesDto>> GetAllGames();
    }
}

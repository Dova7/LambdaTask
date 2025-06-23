using Application.Contracts.IServices.Main;
using Application.Models.Main.Dtos.Games;
using LambdaTask.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LambdaTask.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGames();

            var response = new APIResponse
            {
                IsSuccess = true,
                Result = games,
                Message = "Games retrieved successfully.",
                StatusCode = StatusCodes.Status200OK
            };
            
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpPost("play")]
        public async Task<IActionResult> PlayGame([FromBody] PlayGameDto playGameDto)
        {
            var gameResultDto = await _gameService.PlayGame(playGameDto);

            var response = new APIResponse
            {
                IsSuccess = true,
                Message = "Game played.",
                Result = gameResultDto,
                StatusCode = StatusCodes.Status200OK
            };

            return StatusCode(response.StatusCode, response);
        }
    }
}

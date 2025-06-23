using Application.Contracts.Common;
using Application.Contracts.IRepositories;
using Application.Contracts.IServices.Identity;
using Application.Contracts.IServices.Main;
using Application.Extensions;
using Application.Models.Main.Dtos.Games;
using AutoMapper;
using Domain.Constants.Enums;
using Domain.Entities;

namespace Application.Services.Main
{
    public class GameService : IGameService
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly ILedgerRepository _ledgerRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedLock _distributedLock;
        private readonly Random _random;

        private const int WinMultiplier = 2;

        public GameService(IBalanceRepository balanceRepository, ILedgerRepository ledgerRepository,
            ICurrentUserService currentUserService, IGameRepository gameRepository, IMapper mapper, IDistributedLock distributedLock)
        {
            _balanceRepository = balanceRepository;
            _ledgerRepository = ledgerRepository;
            _currentUserService = currentUserService;
            _gameRepository = gameRepository;
            _mapper = mapper;
            _random = new Random();
            _distributedLock = distributedLock;
        }

        public async Task<GameResultDto> PlayGame(PlayGameDto playGameDto)
        {
            var userId = await _currentUserService.GetUserIdAsync();
            var balance = await _balanceRepository.GetByUserIdAndCurrencyAsync(userId, playGameDto.Currency)
                ?? throw new InvalidOperationException($"Balance for {playGameDto.Currency} not found.");

            if (playGameDto.Amount <= 0)
            {
                throw new InvalidOperationException("Amount must be greater than zero");
            }
            if (balance.Amount < playGameDto.Amount)
            {
                throw new InvalidOperationException("Insufficient balance to play the game.");
            }

            var lockKey = balance.Id.ToAdvisoryKey();
            GameResultDto gameResultDto = new GameResultDto();
            

            await _distributedLock.RunLockedAsync(lockKey, async () =>
            {
                var freshBalance = await _balanceRepository.GetByUserIdAndCurrencyAsync(userId, playGameDto.Currency)
                    ?? throw new InvalidOperationException($"Balance for {playGameDto.Currency} not found.");

                freshBalance.Amount -= playGameDto.Amount;

                var games = await _gameRepository.GetAllAsync();
                var game = games.FirstOrDefault(g => g.Id == playGameDto.GameId);

                if (game == null)
                {
                    throw new InvalidOperationException("Game not found.");
                }

                var betPlaced = new LedgerEntry
                {
                    BalanceId = freshBalance.Id,
                    Amount = playGameDto.Amount,
                    TransactionDescription = TransactionDescription.Betplaced,
                    GameId = game.Id,
                    TimeStamp = DateTime.UtcNow
                };
                await _ledgerRepository.AddAsync(betPlaced);

                gameResultDto.IsWin = _random.Next(0, 2) == 1;

                if (gameResultDto.IsWin)
                {
                    int winAmount = playGameDto.Amount * WinMultiplier;
                    gameResultDto.Amount = winAmount;
                    freshBalance.Amount += winAmount;
                    var winEntry = new LedgerEntry
                    {
                        BalanceId = freshBalance.Id,
                        Amount = winAmount,
                        TransactionDescription = TransactionDescription.Betwon,
                        TimeStamp = DateTime.UtcNow
                    };
                    await _ledgerRepository.AddAsync(winEntry);
                }

                await _balanceRepository.Save();
                await _ledgerRepository.Save();
            });
            return gameResultDto;
        }

        public async Task<List<GetAllGamesDto>> GetAllGames()
        {
            var games = await _gameRepository.GetAllAsync();
            if (games == null || !games.Any())
            {
                throw new InvalidOperationException("No games found.");
            }
            return _mapper.Map<List<GetAllGamesDto>>(games);
        }
    }
}
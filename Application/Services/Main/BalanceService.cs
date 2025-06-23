using Application.Contracts.Common;
using Application.Contracts.IRepositories;
using Application.Contracts.IServices.Identity;
using Application.Contracts.IServices.Main;
using Application.Extensions;
using Application.Models.Main.Dtos.Balances;
using AutoMapper;
using Domain.Constants.Enums;
using Domain.Entities;

namespace Application.Services.Main
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly ILedgerRepository _ledgerRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDistributedLock _distributedLock;
        public BalanceService(ILedgerRepository ledgerRepository, IMapper mapper, IBalanceRepository balanceRepository,
            ICurrentUserService currentUserService, IDistributedLock distributedLock)
        {
            _ledgerRepository = ledgerRepository;
            _mapper = mapper;
            _balanceRepository = balanceRepository;
            _currentUserService = currentUserService;
            _distributedLock = distributedLock;
        }
        public async Task AddAmountToBalanceAsync(AddToBalanceDto addToBalanceDto)
        {
            if (addToBalanceDto.Amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(addToBalanceDto.Amount));
            }
            var userId = await _currentUserService.GetUserIdAsync();

            var balance = await _balanceRepository.GetByUserIdAndCurrencyAsync(userId, addToBalanceDto.Currency)
                ?? throw new InvalidOperationException($"Balance for {addToBalanceDto.Currency} not found.");

            var lockKey = balance.Id.ToAdvisoryKey();

            await _distributedLock.RunLockedAsync(lockKey, async () =>
            {
                var freshBalance = await _balanceRepository.GetByUserIdAndCurrencyAsync(userId, addToBalanceDto.Currency)
                    ?? throw new InvalidOperationException($"Balance for {addToBalanceDto.Currency} not found.");

                freshBalance.Amount += addToBalanceDto.Amount;

                var ledgerEntry = new LedgerEntry
                {
                    BalanceId = freshBalance.Id,
                    Amount = addToBalanceDto.Amount,
                    TransactionDescription = TransactionDescription.Deposit,
                    TimeStamp = DateTime.UtcNow
                };
                await _ledgerRepository.AddAsync(ledgerEntry);

                await _balanceRepository.Save();
                await _ledgerRepository.Save();
            });
        }
        public async Task<List<GetAllBalancesDto>> GetAllBalancesAsync()
        {
            var userId = await _currentUserService.GetUserIdAsync();
            var balances = await _balanceRepository.GetByUserIdAsync(userId);
            if (!balances.Any())
            {
                throw new InvalidOperationException("No balances found for the user.");
            }
            return _mapper.Map<List<GetAllBalancesDto>>(balances);
        }
        public async Task<GetBalanceInfoDto> GetBalanceInfoAsync(Currency currency)
        {
            var userId = await _currentUserService.GetUserIdAsync();
            var balance = await _balanceRepository.GetByUserIdAndCurrencyAsync(userId, currency)
                ?? throw new InvalidOperationException($"Balance for {currency} not found.");

            var balanceInfo = _mapper.Map<GetBalanceInfoDto>(balance);
            return balanceInfo;
        }
        public async Task WithdrawFromBalanceAsync(WithdrawFromBalanceDto withdrawFromBalanceDto)
        {
            if (withdrawFromBalanceDto.Amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(withdrawFromBalanceDto.Amount));
            }

            var userId = await _currentUserService.GetUserIdAsync();
            var balance = await _balanceRepository.GetByUserIdAndCurrencyAsync(userId, withdrawFromBalanceDto.Currency)
                ?? throw new InvalidOperationException($"Balance for {withdrawFromBalanceDto.Currency} not found.");

            if (balance.Amount < withdrawFromBalanceDto.Amount)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }

            var lockKey = balance.Id.ToAdvisoryKey();

            await _distributedLock.RunLockedAsync(lockKey, async () =>
            {
                var freshBalance = await _balanceRepository.GetByUserIdAndCurrencyAsync(userId, withdrawFromBalanceDto.Currency)
                    ?? throw new InvalidOperationException($"Balance for {withdrawFromBalanceDto.Currency} not found.");
                if (freshBalance.Amount < withdrawFromBalanceDto.Amount)
                {
                    throw new InvalidOperationException("Insufficient funds for withdrawal.");
                }

                freshBalance.Amount -= withdrawFromBalanceDto.Amount;

                var ledgerEntry = new LedgerEntry
                {
                    BalanceId = freshBalance.Id,
                    Amount = withdrawFromBalanceDto.Amount,
                    TransactionDescription = TransactionDescription.Withdraw,
                    TimeStamp = DateTime.UtcNow
                };

                await _ledgerRepository.AddAsync(ledgerEntry);

                await _balanceRepository.Save();
                await _ledgerRepository.Save();
            });           
        }
    }
}

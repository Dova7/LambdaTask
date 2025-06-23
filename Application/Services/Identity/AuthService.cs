using Application.Contracts.IRepositories;
using Application.Contracts.IServices.Identity;
using Application.Models.Identity.Dtos;
using AutoMapper;
using Domain.Constants.Enums;
using Domain.Entities;
using Domain.Entities.Identity;
using System.Transactions;

namespace Application.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly IBalanceRepository _balanceRepository;
        public AuthService(IBalanceRepository balanceRepository, IUserRepository userRepository, IJwtGenerator jwtGenerator, IPasswordService passwordService, IMapper mapper)
        {
            _balanceRepository = balanceRepository;
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginDto)
        {
            var user = await _userRepository.GetByUserNameAsync(loginDto.UserName) 
                ?? throw new KeyNotFoundException("Invalid Credentials.");

            var isPasswordValid = await _passwordService.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
            {
                throw new InvalidOperationException("Invalid Credentials.");
            }
            var roles = await _userRepository.GetUserRolesAsync(user);            
            var token = _jwtGenerator.GenerateToken(user, roles);
            return new LoginResponseDto
            {
                Token = token
            };
        }

        public async Task Register(RegistrationRequestDto registerDto)
        {

            if (registerDto == null)
            {
                throw new ArgumentNullException(nameof(registerDto), "Registration data cannot be null.");
            }
            if (await _userRepository.ExistsByEmailAsync(registerDto.Email))
            {
                throw new InvalidOperationException($"User with email {registerDto.Email} already exists.");
            }
            if (await _userRepository.ExistsByUserNameAsync(registerDto.UserName))
            {
                throw new InvalidOperationException($"User with username {registerDto.UserName} already exists.");
            }

            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                var user = _mapper.Map<ApplicationUser>(registerDto);
                user.Id = Guid.NewGuid();


                await _userRepository.CreateAsync(user, registerDto.Password);
                await _userRepository.AddToRoleAsync(user, "User");

                if (user == null)
                {
                    throw new InvalidOperationException("User registration failed.");
                }

                foreach (Currency currency in Enum.GetValues(typeof(Currency)))
                {
                    var balance = new Balance
                    {
                        UserId = user.Id,
                        Currency = currency,
                        Amount = 0
                    };
                    await _balanceRepository.AddAsync(balance);
                }

                await _balanceRepository.Save();
                scope.Complete();
            }
            catch (Exception)
            {
                throw;
            }                        
        }
    }
}

using Application.Contracts.IRepositories;
using Application.Contracts.IServices.Identity;
using Application.Models.Identity.Dtos;
using AutoMapper;

namespace Application.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly ICurrentUserService _currentUserService;
        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordService passwordService, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _currentUserService = currentUserService;
        }

        public async Task<List<GetAllUsersDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<List<GetAllUsersDto>>(users);
        }

        public async Task<GetUserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> GetUserByUsernameAsync(string userName)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> UpdateUserInfoAsync(UpdateUserInfoDto updateUserDto)
        {
            var id = await _currentUserService.GetUserIdAsync();
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            var isPasswordValid = await _passwordService.CheckPasswordAsync(user, updateUserDto.CurrentPassword);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Current password is incorrect");
            }
            _mapper.Map(updateUserDto, user);
            var updatedUser = await _userRepository.UpdateAsync(user);
            return _mapper.Map<GetUserDto>(updatedUser);
        }
    }
}

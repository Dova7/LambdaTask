using Application.Models.Identity.Dtos;

namespace Application.Contracts.IServices.Identity
{
    public interface IUserService
    {
        Task<List<GetAllUsersDto>> GetAllUsersAsync();
        Task<GetUserDto> GetUserByUsernameAsync(string userName);
        Task<GetUserDto> GetUserByEmailAsync(string email);
        Task<GetUserDto> GetUserByIdAsync(Guid id);
        Task<GetUserDto> UpdateUserInfoAsync(UpdateUserInfoDto updateUserDto);
    }
}

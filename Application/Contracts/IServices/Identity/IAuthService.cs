using Application.Models.Identity.Dtos;

namespace Application.Contracts.IServices.Identity
{
    public interface IAuthService
    {
        Task Register(RegistrationRequestDto registerDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginDto);
    }
}

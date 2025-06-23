using Domain.Entities.Identity;

namespace Application.Contracts.IServices.Identity
{
    public interface IPasswordService
    {
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    }
}

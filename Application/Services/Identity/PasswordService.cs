using Application.Contracts.IServices.Identity;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Identity
{
    public class PasswordService : IPasswordService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public PasswordService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}

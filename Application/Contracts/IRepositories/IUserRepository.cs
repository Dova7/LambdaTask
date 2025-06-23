using Application.Contracts.Common;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.IRepositories
{
    public interface IUserRepository : IFullyUpdatable<ApplicationUser>
    {
        Task<ApplicationUser?> GetByUserNameAsync(string userName);
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<bool> ExistsByUserNameAsync(string userName);
        Task<bool> ExistsByEmailAsync(string email);
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser?> GetByIdAsync(Guid id);
        Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string roleName);
        Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string roleName);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> DeleteAsync(ApplicationUser user);
    }
}
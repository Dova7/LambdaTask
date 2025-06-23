using Application.Contracts.IRepositories;
using Domain.Entities.Identity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Identity
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                throw new InvalidOperationException($"Role '{roleName}' does not exist.");
            }
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new InvalidOperationException(
                    $"Failed to add user to role '{roleName}': {string.Join("; ", errors)}");
            }
            return result;
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                throw new InvalidOperationException($"Role '{roleName}' does not exist.");
            }
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new InvalidOperationException(
                    $"Failed to remove user from role '{roleName}': {string.Join("; ", errors)}");
            }
            return result;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new InvalidOperationException(
                    $"Failed to create user: {string.Join("; ", errors)}");
            }
            return result;
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new InvalidOperationException(
                    $"Failed to delete user: {string.Join("; ", errors)}");
            }
            return result;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _userManager.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsByUserNameAsync(string userName)
        {
            return await _userManager.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<ApplicationUser?> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<ApplicationUser?> GetByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new InvalidOperationException(
                    $"Failed to update user: {string.Join("; ", errors)}");
            }
            return user;
        }
    }
}

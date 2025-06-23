using Application.Contracts.IServices.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Authentication
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public async Task<Guid> GetUserIdAsync()
        {
            var idValue = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(idValue, out var id))
                throw new InvalidOperationException("User is not authenticated or has no valid ID.");
            return await Task.FromResult(id);
        }

        public async Task<string> GetUserNameAsync()
        {
            var name = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("User is not authenticated or has no name.");
            }
            return await Task.FromResult(name);
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync()
        {
            var roles = _httpContextAccessor.HttpContext?
                .User?.FindAll(ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList()
                ?? new List<string>();

            if (!roles.Any())
                throw new InvalidOperationException("User is not in any roles.");
            return await Task.FromResult(roles);
        }
    }
}

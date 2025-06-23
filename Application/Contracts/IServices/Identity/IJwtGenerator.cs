using Domain.Entities.Identity;

namespace Application.Contracts.IServices.Identity
{
    public interface IJwtGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}

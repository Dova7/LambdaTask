using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string DisplayName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public ICollection<Balance> Balances { get; set; } = new List<Balance>();
    }
}

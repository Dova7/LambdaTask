using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplicationUserConstraints();
            builder.BalanceConstraints();
            builder.LedgerEntryConstraints();

            builder.SeedRoles();
            builder.SeedUsers();
            builder.SeedUserRoles();
            builder.SeedBalanaces();
            builder.SeedGames();
        }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<LedgerEntry> LedgerEntries { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}

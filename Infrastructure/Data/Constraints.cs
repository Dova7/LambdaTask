using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class Constraints
    {
        public static void ApplicationUserConstraints(this ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                e.Property(x => x.Email).IsRequired().HasMaxLength(254);
                e.Property(x => x.UserName).IsRequired().HasMaxLength(50);
                e.Property(x => x.DisplayName).HasMaxLength(50);
                e.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
                e.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            });
            builder.Entity<ApplicationUser>().HasMany(x => x.Balances).WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public static void BalanceConstraints(this ModelBuilder builder)
        {
            builder.Entity<Balance>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                e.Property(x => x.Amount).IsRequired();
                e.Property(x => x.Currency).IsRequired().HasConversion<string>();
            });
            builder.Entity<Balance>().HasMany(x => x.LedgerEntries).WithOne(x => x.Balance)
                .HasForeignKey(x => x.BalanceId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static void LedgerEntryConstraints(this ModelBuilder builder)
        {
            builder.Entity<LedgerEntry>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                e.Property(x => x.Amount).IsRequired();
                e.Property(x => x.TimeStamp).IsRequired();
                e.Property(x => x.TransactionDescription).IsRequired().HasConversion<string>().HasMaxLength(50);
                e.Property(x => x.GameId).IsRequired(false);
            });
            builder.Entity<LedgerEntry>().HasOne(x => x.Game)
                .WithMany().HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
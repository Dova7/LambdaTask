using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void SeedRoles(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> { Id = new Guid("A69D219B-BB64-4AE9-B0C6-261DA24D52D2"), Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole<Guid> { Id = new Guid("12C11B67-5466-4A81-AD5C-6D35FCE015F1"), Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<Guid> { Id = new Guid("1C2EA9D7-9FD2-40A8-85F4-72A4D4608062"), Name = "User", NormalizedName = "USER" }
            );
        }

        public static void SeedUsers(this ModelBuilder builder)
        {
            PasswordHasher<ApplicationUser> hasher = new();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = new Guid("1365FCBA-5EBF-45B9-B67C-11DC33B91B12"),
                    FirstName = "SUPERADMIN",
                    LastName = "SUPERADMIN",
                    DisplayName = "SUPERADMIN",
                    Email = "SUPERADMIN@gmail.com",
                    UserName = "SUPERADMIN",
                    NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                    NormalizedUserName = "SUPERADMIN",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "MainAdmin123!"),
                    PhoneNumber = "555337681",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                },
                new ApplicationUser()
                {
                    Id = new Guid("EC4A0AD9-5AA4-4F70-9AB6-F37246664EFF"),
                    FirstName = "John",
                    LastName = "Doe",
                    DisplayName = "JDoe",
                    Email = "jdoe@gmail.com",
                    UserName = "jdoe",
                    NormalizedEmail = "JDOE@GMAIL.COM",
                    NormalizedUserName = "JDOE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "JohnDoe123!"),
                    PhoneNumber = "525337631",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                },
                new ApplicationUser()
                {
                    Id = new Guid("C79EEA5E-34FC-480B-A4DF-7BD440D6C684"),
                    FirstName = "Jane",
                    LastName = "Doe",
                    DisplayName = "Jane",
                    Email = "Jane.Doe@gmail.com",
                    UserName = "Jane123",
                    NormalizedEmail = "JANE.DOE@GMAIL.COM",
                    NormalizedUserName = "JANE123",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "JaneDoe123!"),
                    PhoneNumber = "155327601",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                },
                new ApplicationUser()
                {
                    Id = new Guid("31284E51-C5D0-4A66-9497-92D2F0DED4BF"),
                    FirstName = "James",
                    LastName = "White",
                    DisplayName = "JWhite",
                    Email = "j.white@gmail.com",
                    UserName = "white123",
                    NormalizedEmail = "J.WHITE@GMAIL.COM",
                    NormalizedUserName = "WHITE123",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "JohnWhite123!"),
                    PhoneNumber = "525310601",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                }
                );
        }

        public static void SeedUserRoles(this ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { UserId = new Guid("1365FCBA-5EBF-45B9-B67C-11DC33B91B12"), RoleId = new Guid("A69D219B-BB64-4AE9-B0C6-261DA24D52D2") },
                new IdentityUserRole<Guid> { UserId = new Guid("EC4A0AD9-5AA4-4F70-9AB6-F37246664EFF"), RoleId = new Guid("12C11B67-5466-4A81-AD5C-6D35FCE015F1") },
                new IdentityUserRole<Guid> { UserId = new Guid("C79EEA5E-34FC-480B-A4DF-7BD440D6C684"), RoleId = new Guid("1C2EA9D7-9FD2-40A8-85F4-72A4D4608062") },
                new IdentityUserRole<Guid> { UserId = new Guid("31284E51-C5D0-4A66-9497-92D2F0DED4BF"), RoleId = new Guid("1C2EA9D7-9FD2-40A8-85F4-72A4D4608062") }
            );
        }

        public static void SeedBalanaces(this ModelBuilder builder)
        {
            builder.Entity<Balance>().HasData(
                new Balance
                {
                    Id = new Guid("25238630-5128-4E60-BB20-D74294D27E0F"),
                    UserId = new Guid("C79EEA5E-34FC-480B-A4DF-7BD440D6C684"),
                    Amount = 1000,
                    Currency = Domain.Constants.Enums.Currency.GEL,
                },
                new Balance
                {
                    Id = new Guid("60CF14C1-EA82-4D9F-BC46-EE5EB7CCB2EF"),
                    UserId = new Guid("C79EEA5E-34FC-480B-A4DF-7BD440D6C684"),
                    Amount = 1000,
                    Currency = Domain.Constants.Enums.Currency.USD,
                },
                new Balance
                {
                    Id = new Guid("C3042A39-B938-46B8-A61E-ED0554A7950F"),
                    UserId = new Guid("C79EEA5E-34FC-480B-A4DF-7BD440D6C684"),
                    Amount = 1000,
                    Currency = Domain.Constants.Enums.Currency.EUR,
                },

                new Balance
                {
                    Id = new Guid("F0EDD732-876B-4879-BF97-8A9793107EB6"),
                    UserId = new Guid("31284E51-C5D0-4A66-9497-92D2F0DED4BF"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.GEL,
                },
                new Balance
                {
                    Id = new Guid("2EB6F3B2-3064-4583-97DB-C0D1758AFF08"),
                    UserId = new Guid("31284E51-C5D0-4A66-9497-92D2F0DED4BF"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.USD,
                }, new Balance
                {
                    Id = new Guid("F2D497CB-ED02-4F32-AD0A-37D4A18E0655"),
                    UserId = new Guid("31284E51-C5D0-4A66-9497-92D2F0DED4BF"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.EUR,
                },

                new Balance
                {
                    Id = new Guid("AF3FBCB8-B29E-4233-8C34-9AE529F5943A"),
                    UserId = new Guid("1365FCBA-5EBF-45B9-B67C-11DC33B91B12"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.GEL,
                },
                new Balance
                {
                    Id = new Guid("D828DA65-F3CA-4EBD-A5A1-CA0A1F92C171"),
                    UserId = new Guid("1365FCBA-5EBF-45B9-B67C-11DC33B91B12"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.USD,
                },
                new Balance
                {
                    Id = new Guid("F6F338E8-3E16-4A5F-9D8B-41694C434FAE"),
                    UserId = new Guid("1365FCBA-5EBF-45B9-B67C-11DC33B91B12"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.EUR,
                },

                new Balance
                {
                    Id = new Guid("817B5A71-CDDE-4899-BF32-F685CA0ADDA2"),
                    UserId = new Guid("EC4A0AD9-5AA4-4F70-9AB6-F37246664EFF"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.GEL,
                },
                new Balance
                {
                    Id = new Guid("74311927-5419-4AE4-B108-E8AA66B5048C"),
                    UserId = new Guid("EC4A0AD9-5AA4-4F70-9AB6-F37246664EFF"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.USD,
                },
                new Balance
                {
                    Id = new Guid("F0A99876-A81E-481B-8D41-C614907C7C89"),
                    UserId = new Guid("EC4A0AD9-5AA4-4F70-9AB6-F37246664EFF"),
                    Amount = 500,
                    Currency = Domain.Constants.Enums.Currency.EUR,
                }
            );
        }

        public static void SeedGames(this ModelBuilder builder)
        {
            builder.Entity<Game>().HasData(
                new Game
                {
                    Id = new Guid("94078DB3-2FD2-4DE9-9F16-2B34036C99B9"),
                    GameName = "Game 1",                    
                },
                new Game
                {
                    Id = new Guid("457158EC-B964-4287-B441-75599A9013BC"),
                    GameName = "Game 2",
                }
            );
        }
    }
}

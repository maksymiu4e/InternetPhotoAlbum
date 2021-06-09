using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Shared.Shared.Enums;

namespace DAL.Data
{
    public static class DataBaseInitialization
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            User[] users = new[]
            {
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johnDoe@gmail.com"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Steve",
                    LastName = "Lee",
                    Email = "STlee@gmail.com"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Admin",
                    LastName = "Stepanovych",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                }
            };
            IdentityRole<int>[] roles = new[]
            {
                new IdentityRole<int>
                {
                    Id = (int)UserRole.Guest,
                    Name = UserRole.Guest.ToString(),
                    NormalizedName = UserRole.Guest.ToString().ToUpper()
                },
                new IdentityRole<int>
                {
                    Id = (int)UserRole.Registered,
                    Name = UserRole.Registered.ToString(),
                    NormalizedName = UserRole.Registered.ToString().ToUpper()
                },
                new IdentityRole<int>
                {
                    Id = (int)UserRole.Admin,
                    Name = UserRole.Admin.ToString(),
                    NormalizedName = UserRole.Admin.ToString().ToUpper()
                }
            };
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<IdentityRole<int>>().HasData(roles);

        }
    }
}

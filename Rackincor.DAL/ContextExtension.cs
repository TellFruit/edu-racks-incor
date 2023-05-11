using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Racksincor.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL
{
    internal static class ContextExtension
    {
        public static void Configure(this ModelBuilder builder)
        {
            builder.Entity<Reaction>()
                .HasKey(sc => new { sc.UserId, sc.ProductId });
        }

        public static void Seed(this ModelBuilder builder)
        {
            var passwordHasher = new PasswordHasher<User>();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Shopper",
                    NormalizedName = "SHOPPER"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
            );

            builder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "Admin123!"),
                    SecurityStamp = string.Empty
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "1"
                }
            );
        }
    }
}

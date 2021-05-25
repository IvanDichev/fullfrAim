using FullFraim.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Shared;
using System;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public class UserSeed : IEntityTypeConfiguration<User>,
        IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        private readonly IConfiguration configuration;

        public UserSeed(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var passHasher = new PasswordHasher<User>();

            var usersToSeed = new List<User>
            {
                new User()
                {
                    Id = 1,
                    FirstName = this.configuration["AccountAdminInfo:UserName"],
                    LastName = this.configuration["AccountAdminInfo:LastName"],
                    UserName = this.configuration["AccountAdminInfo:UserName"],
                    NormalizedUserName = this.configuration["AccountAdminInfo:UserName"].ToUpper(),
                    Email = this.configuration["AccountAdminInfo:Email"],
                    NormalizedEmail = this.configuration["AccountAdminInfo:UserName"].ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                },
                new User()
                {
                    Id = 2,
                    FirstName = Constants.UserSeed.Valentin,
                    LastName = Constants.UserSeed.Shikov,
                    UserName = Constants.UserSeed.VShikovEmail,
                    NormalizedUserName = Constants.UserSeed.VShikovEmail.ToUpper(),
                    Email = Constants.UserSeed.VShikovEmail,
                    NormalizedEmail = Constants.UserSeed.VShikovEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
                new User()
                {
                    Id = 3,
                    FirstName = Constants.UserSeed.Ivan,
                    LastName = Constants.UserSeed.Dichev,
                    UserName = Constants.UserSeed.IDichevEmail,
                    NormalizedUserName = Constants.UserSeed.IDichevEmail.ToUpper(),
                    Email = Constants.UserSeed.IDichevEmail,
                    NormalizedEmail = Constants.UserSeed.IDichevEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
                new User()
                {
                    Id = 4,
                    FirstName = Constants.UserSeed.Boryana,
                    LastName = Constants.UserSeed.BMihaylovaEmail,
                    UserName = Constants.UserSeed.BMihaylovaEmail,
                    NormalizedUserName = Constants.UserSeed.BMihaylovaEmail.ToUpper(),
                    Email = Constants.UserSeed.BMihaylovaEmail,
                    NormalizedEmail = Constants.UserSeed.BMihaylovaEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
                new User()
                {
                    Id = 5,
                    FirstName = Constants.UserSeed.Dimitar,
                    LastName = Constants.UserSeed.Dimitrov,
                    UserName = Constants.UserSeed.DDimitrovEmail,
                    NormalizedUserName = Constants.UserSeed.DDimitrovEmail.ToUpper(),
                    Email = Constants.UserSeed.DDimitrovEmail,
                    NormalizedEmail = Constants.UserSeed.DDimitrovEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },
                new User()
                {
                    Id = 6,
                    FirstName = Constants.UserSeed.Emily,
                    LastName = Constants.UserSeed.Ivanova,
                    UserName = Constants.UserSeed.EIvanovaEmail,
                    NormalizedUserName = Constants.UserSeed.EIvanovaEmail.ToUpper(),
                    Email = Constants.UserSeed.EIvanovaEmail,
                    NormalizedEmail = Constants.UserSeed.EIvanovaEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    Points = 0,
                },

            };

            usersToSeed[0].PasswordHash = passHasher
                .HashPassword(usersToSeed[0], this.configuration["AccountAdminInfo:Password"]);

            builder
                .HasData(usersToSeed);
        }

        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            // RoleId 1 -> Admin
            // RoleId 2 -> Organizer
            // RoleId 3 -> User
            builder.HasData(
                new IdentityUserRole<int>()
                {
                    RoleId = 1,
                    UserId = 1,
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 2,
                    UserId = 1,
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 3,
                    UserId = 1,
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 3,
                    UserId = 2,
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 3,
                    UserId = 3,
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 3,
                    UserId = 4,
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 3,
                    UserId = 5,
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 3,
                    UserId = 6,
                });
        }
    }
}

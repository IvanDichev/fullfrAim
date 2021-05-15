using FullFraim.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;
using System;

namespace FullFraim.Data.Seed
{
    public class UserSeed : IEntityTypeConfiguration<User>, 
        IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var passHasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = 1,
                FirstName = Constants.UserSeed.FirstName,
                LastName = Constants.UserSeed.LastName,
                UserName = Constants.UserSeed.UserName,
                NormalizedUserName = Constants.UserSeed.UserName.ToUpper(),
                Email = Constants.UserSeed.Email,
                NormalizedEmail = Constants.UserSeed.UserName.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            user.PasswordHash = passHasher
                .HashPassword(user, Constants.UserSeed.Password);

            builder
                .HasData(user);
        }

        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(new IdentityUserRole<int>()
            {
                RoleId = 1,
                UserId = 1
            });
        }
    }
}

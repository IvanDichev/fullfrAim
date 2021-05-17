using FullFraim.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Shared;
using System;

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

            var user = new User()
            {
                Id = 1,
                FirstName = this.configuration["AccountAdminInfo:UserName"],
                LastName = this.configuration["AccountAdminInfo:LastName"],
                UserName = this.configuration["AccountAdminInfo:UserName"],
                NormalizedUserName = this.configuration["AccountAdminInfo:UserName"].ToUpper(),
                Email = this.configuration["AccountAdminInfo:Email"],
                NormalizedEmail = this.configuration["AccountAdminInfo:UserName"].ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            user.PasswordHash = passHasher
                .HashPassword(user, this.configuration["AccountAdminInfo:Password"]);

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

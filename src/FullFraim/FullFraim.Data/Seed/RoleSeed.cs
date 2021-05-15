﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;

namespace FullFraim.Data.Seed
{
    public class RoleSeed : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(new IdentityRole<int>()
            {
                Id = 1,
                Name = Constants.RolesSeed.Admin,
                NormalizedName = Constants.RolesSeed.Admin.ToUpper()
            },
            new IdentityRole<int>()
            {
                Id = 2,
                Name = Constants.RolesSeed.Organizer,
                NormalizedName = Constants.RolesSeed.Organizer.ToUpper()
            },
            new IdentityRole<int>()
            {
                Id = 3,
                Name = Constants.RolesSeed.Jury,
                NormalizedName = Constants.RolesSeed.Jury.ToUpper()
            },
            new IdentityRole<int>()
            {
                Id = 4,
                Name = Constants.RolesSeed.Participant,
                NormalizedName = Constants.RolesSeed.Participant.ToUpper()
            },
            new IdentityRole<int>()
            {
                Id = 5,
                Name = Constants.RolesSeed.PhotoMaster,
                NormalizedName = Constants.RolesSeed.PhotoMaster.ToUpper()
            });
        }
    }
}

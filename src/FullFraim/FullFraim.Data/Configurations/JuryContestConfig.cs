﻿using FullFraim.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullFraim.Data.Configurations
{
    class JuryContestConfig : IEntityTypeConfiguration<JuryContest>
    {
        public void Configure(EntityTypeBuilder<JuryContest> builder)
        {
            builder.HasKey(k => new { k.ContestId, k.UserId });
        }
    }
}
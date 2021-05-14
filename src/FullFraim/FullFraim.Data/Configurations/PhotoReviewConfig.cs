﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FullFraim.Data.Models;

namespace FullFraim.Data.Configurations
{
    public class PhotoReviewConfig : IEntityTypeConfiguration<PhotoReview>
    {
        public void Configure(EntityTypeBuilder<PhotoReview> builder)
        {
            builder
                .HasOne(r => r.User)
                .WithMany(u => u.PhotoReviews)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

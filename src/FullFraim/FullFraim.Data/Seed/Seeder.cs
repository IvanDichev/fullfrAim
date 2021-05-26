using FullFraim.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContestCategory>().HasData(new List<ContestCategory>());
            modelBuilder.Entity<Contest>().HasData(new List<Contest>());
            modelBuilder.Entity<ContestPhase>().HasData(new List<ContestPhase>());
            modelBuilder.Entity<ContestType>().HasData(new List<ContestType>());
            modelBuilder.Entity<Phase>().HasData(new List<Phase>());
            modelBuilder.Entity<PhotoReview>().HasData(new List<PhotoReview>());
            modelBuilder.Entity<Photo>().HasData(new List<Photo>());
            modelBuilder.Entity<ParticipantContest>().HasData(new List<ParticipantContest>());
            modelBuilder.Entity<Rank>().HasData(new List<Rank>());
            modelBuilder.Entity<JuryContest>().HasData(new List<JuryContest>());
        }
    }
}

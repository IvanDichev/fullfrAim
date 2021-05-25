using FullFraim.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FullFraim.Data.Seed
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContestCategory>().HasData(ContestCategoriesSeed.SeedData);
            modelBuilder.Entity<Contest>().HasData(ContestsSeed.SeedData);
            modelBuilder.Entity<ContestType>().HasData(ContestTypesSeed.SeedData);
            modelBuilder.Entity<Phase>().HasData(PhasesSeed.SeedData);
            modelBuilder.Entity<PhotoReview>().HasData(PhotoReviewsSeed.SeedData);
            modelBuilder.Entity<Photo>().HasData(PhotosSeed.SeedData);
            modelBuilder.Entity<ParticipantContest>().HasData(ParticipantContestsSeed.SeedData);
            modelBuilder.Entity<Rank>().HasData(RanksSeed.SeedData);
        }
    }
}

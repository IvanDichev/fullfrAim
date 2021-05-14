using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FullFraim.Data.Models;

namespace FullFraim.Data.Configurations
{
    public class UserContestConfig : IEntityTypeConfiguration<UserContest>
    {
        public void Configure(EntityTypeBuilder<UserContest> builder)
        {
            builder
                .HasKey(k => new { k.UserId, k.ContestId });
        }
    }
}

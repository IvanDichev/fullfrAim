using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoContest.Data.Models;

namespace PhotoContest.Data.Configurations
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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FullFraim.Data.Models;

namespace FullFraim.Data.Configurations
{
    public class ParticipantContestConfig : IEntityTypeConfiguration<ParticipantContest>
    {
        public void Configure(EntityTypeBuilder<ParticipantContest> builder)
        {
            builder.Property(pc => pc.Id).IsRequired(false);
            builder.HasKey(pc => new { pc.UserId, pc.ContestId });

            builder.HasQueryFilter(pc => !pc.IsDeleted);
        }
    }
}

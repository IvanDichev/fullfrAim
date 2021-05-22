using FullFraim.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullFraim.Data.Configurations
{
    class JuryContestConfig : IEntityTypeConfiguration<JuryContest>
    {
        public void Configure(EntityTypeBuilder<JuryContest> builder)
        {
            builder.Property(jc => jc.Id).IsRequired(false);
            builder.HasKey(jc => new { jc.ContestId, jc.UserId });

            builder.HasQueryFilter(jc => !jc.IsDeleted);
        }
    }
}

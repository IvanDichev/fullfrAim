using FullFraim.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullFraim.Data.Configurations
{
    public class ContestPhaseConfig : IEntityTypeConfiguration<ContestPhase>
    {
        public void Configure(EntityTypeBuilder<ContestPhase> builder)
        {
            builder.HasQueryFilter(cp => !cp.IsDeleted);
        }
    }
}

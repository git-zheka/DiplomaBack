using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoloLearn.Models.Entities;
using VoloLearn.Models.Enum;

namespace VoloLearn.Models.EntityConfig;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasOne(x => x.CreatedBy);
        builder.Property(x => x.Status).HasDefaultValue(AssignmentStatus.InProgress);
    }
}
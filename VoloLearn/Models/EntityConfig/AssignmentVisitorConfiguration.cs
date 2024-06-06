using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoloLearn.Models.Entities;

namespace VoloLearn.Models.EntityConfig;

public class AssignmentVisitorConfiguration : IEntityTypeConfiguration<AssignmentVisitor>
{
    public void Configure(EntityTypeBuilder<AssignmentVisitor> builder)
    {
        builder.HasOne(user => user.User);
        builder.HasOne(user => user.Assignment);
    }
}
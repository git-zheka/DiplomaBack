using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoloLearn.Models.Entities;

namespace VoloLearn.Models.EntityConfig
{
    public class AssignmentVisitorConfiguration : IEntityTypeConfiguration<AssimnetVisitor>
    {
        public void Configure(EntityTypeBuilder<AssimnetVisitor> builder)
        {
            builder.HasOne(user => user.User);
            builder.HasOne(user => user.Assignment);
        }
    }
}

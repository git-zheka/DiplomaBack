using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoloLearn.Models.Entities;

namespace VoloLearn.Models.EntityConfig
{
    public class OrganisationAssignmentConfiguration : IEntityTypeConfiguration<OrganisationAssignments>
    {
        public void Configure(EntityTypeBuilder<OrganisationAssignments> builder)
        {
            builder.HasOne(organisation => organisation.User);
            builder.HasOne(organisation => organisation.Assignment);
        }
    }
}

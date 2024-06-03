using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoloLearn.Constants;
using VoloLearn.Models.Entities;

namespace VoloLearn.Models.EntityConfig
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData
            (
                new Role { Name = DefaultRoleName.VolonteerName },
                new Role { Name = DefaultRoleName.OrganisationName },
                new Role { Name = DefaultRoleName.ModeratorName, IsSuperUser = true },
                new Role { Name = DefaultRoleName.SchoolName}
            ); ;

            builder.HasIndex(x => x.Name).IsUnique(true);
        }
    }
}

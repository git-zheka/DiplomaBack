using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoloLearn.Constants;
using VoloLearn.Models.Entities;

namespace VoloLearn.Models.EntityConfig;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData
        (
            new Role { Id = Guid.NewGuid(), Name = DefaultRoleName.VolonteerName },
            new Role { Id = Guid.NewGuid(), Name = DefaultRoleName.OrganisationName },
            new Role { Id = Guid.NewGuid(), Name = DefaultRoleName.ModeratorName, IsSuperUser = true },
            new Role { Id = Guid.NewGuid(), Name = DefaultRoleName.SchoolName }
        );
        ;

        builder.HasIndex(x => x.Name).IsUnique();
    }
}
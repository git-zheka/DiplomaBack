using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoloLearn.Models.Entities;

namespace VoloLearn.Models.EntityConfig
{
    public class UserScoreConfiguration : IEntityTypeConfiguration<UserScore>
    {
        //DONE
        public void Configure(EntityTypeBuilder<UserScore> builder)
        {
            builder.HasOne(user => user.Visitor);
            builder.HasOne(user => user.assigment);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using VoloLearn.Models.Entities;

namespace VoloLearn.DataBase
{
    public class VoloLearnDbContext : DbContext
    {
        public VoloLearnDbContext(DbContextOptions<VoloLearnDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //TODO: DbSets
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AssimnetVisitor> AssimnetVisitors { get; set; }
        public DbSet<OrganisationAssignments> OrganisationAssignments { get; set;}
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserScore> UserScores { get; set; }
    }


}

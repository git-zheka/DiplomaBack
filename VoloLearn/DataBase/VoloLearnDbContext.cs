using Microsoft.EntityFrameworkCore;
using VoloLearn.Models.Entities;

namespace VoloLearn.DataBase;

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
    public DbSet<AssignmentVisitor> AssignmentVisitors { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<SchoolCourse> SchoolCourses { get; set; }
}
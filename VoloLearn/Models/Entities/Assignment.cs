using VoloLearn.Models.Enum;

namespace VoloLearn.Models.Entities;

public class Assignment : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime EventDate { get; set; }
    public int Goal { get; set; }
    public int Reward { get; set; }

    public Guid CreatedById { get; set; }
    public User? CreatedBy { get; set; }

    public AssignmentStatus Status { get; set; } = AssignmentStatus.InProgress;
}
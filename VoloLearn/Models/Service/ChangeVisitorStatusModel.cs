using VoloLearn.Models.Enum;

namespace VoloLearn.Models.Service;

public class ChangeVisitorStatusModel
{
    public Guid AssignmentId { get; set; }
    public Guid UserId { get; set; }
    public AssignmentVisitStatus Status { get; set; }
}
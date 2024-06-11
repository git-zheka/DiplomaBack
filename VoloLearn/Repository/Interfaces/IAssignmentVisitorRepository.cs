using VoloLearn.Models.Entities;
using VoloLearn.Models.Enum;

namespace VoloLearn.Repository.Interfaces;

public interface IAssignmentVisitorRepository
{
    Task ChangeStatusAsync(Guid assignmentId, Guid userId, AssignmentVisitStatus status);
    Task<List<Assignment>> GetUsersVisitsAsync(Guid userId);
    Task<List<User>> GetAssignmentVisitorsAsync(Guid assignmentId);
    Task<int> CalculateUserScoreAsync(Guid userId);
    Task<Guid> CreateVisitAsync(Guid assignmentId, Guid userId);
}
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Services;

public class AssignmentVisitorService : IAssignmentVisitorService
{
    private readonly IAssignmentVisitorRepository _assignmentVisitorRepository;

    public AssignmentVisitorService(IAssignmentVisitorRepository assignmentVisitorRepository)
    {
        _assignmentVisitorRepository = assignmentVisitorRepository;
    }
}
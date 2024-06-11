using VoloLearn.Models.Entities;
using VoloLearn.Models.Service;
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IUserRepository _userRepository;

    public AssignmentService(IAssignmentRepository assignmentRepository, IUserRepository userRepository)
    {
        _assignmentRepository = assignmentRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> CreateAssignmentAsync(CreateAssignmentModel assignment)
    {

        var assignmentEntity = new Assignment
        {
            Name = assignment.Name,
            Description = assignment.Description,
            EventDate = DateTime.Now,
            Goal = assignment.Goal,
            Reward = assignment.Reward,
        };

        var result = await _assignmentRepository.CreateAssignmentAsync(assignment.UserId, assignmentEntity);
        return result;
    }
}
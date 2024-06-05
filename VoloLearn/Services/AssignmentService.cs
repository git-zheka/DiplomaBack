using VoloLearn.Models.Entities;
using VoloLearn.Models.Service;
using VoloLearn.Repository;
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<Guid> CreateAssignmentAsync(CreateAssignmentModel assignment) 
        {
            var assignmentEntity = new Assignment
            {
                Description = assignment.Description,
            };

            var result = await _assignmentRepository.CreateAssignmentAsync(assignment.UserId, assignmentEntity);
            return result;
        }

    }
}

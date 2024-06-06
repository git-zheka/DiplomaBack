using VoloLearn.Models.Entities;
using VoloLearn.Models.Service;

namespace VoloLearn.Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAllAssignmentAsync();
        Task<Guid> CreateAssignmentAsync(CreateAssignmentModel assignment);
    }
}

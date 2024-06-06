using VoloLearn.Models.Service;

namespace VoloLearn.Services.Interfaces;

public interface IAssignmentService
{
    Task<Guid> CreateAssignmentAsync(CreateAssignmentModel assignment);
}
using VoloLearn.Models.Entities;

namespace VoloLearn.Repository.Interfaces
{
    public interface IAssignmentRepository : IBaseRepository<Assignment>
    {
        Task<Guid> CreateAssignmentAsync(Guid userid, Assignment assignment);
    }
}

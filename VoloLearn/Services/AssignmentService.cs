using VoloLearn.Models.Entities;
using VoloLearn.Repository;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Services
{
    public class AssignmentService
    {
        private readonly IBaseRepository<Assignment> _baseRepository;

        public AssignmentService(IBaseRepository<Assignment> baseRepository)
        {
            _baseRepository = baseRepository;
        }

    }
}

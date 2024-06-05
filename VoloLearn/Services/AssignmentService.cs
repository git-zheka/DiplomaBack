using VoloLearn.Repository;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Services
{
    public class AssignmentService
    {
        private readonly IBaseRepository _baseRepository;

        public AssignmentService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}

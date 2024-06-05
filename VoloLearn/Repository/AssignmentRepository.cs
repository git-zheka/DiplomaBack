using VoloLearn.Constants;
using VoloLearn.DataBase;
using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Repository
{
    public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
    {

        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;    
        public AssignmentRepository(VoloLearnDbContext context, UserRepository userRepository, RoleRepository roleRepository) : base(context)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Guid> CreateAssignmentAsync(Guid userid, Assignment assignment) 
        {
            var founded = await _userRepository.GetByIdAsync(userid);
            var organisationRole = await _roleRepository.GetByNameAsync(DefaultRoleName.OrganisationName);

            if (founded.Role.Id != organisationRole.Id) 
            {
                throw new Exception("You can't create Assigment");
            }

            var result = await CreateAsync(assignment);
            SaveAsync();

            return result;
        }
    }
}

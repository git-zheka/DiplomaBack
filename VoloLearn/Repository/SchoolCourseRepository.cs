using VoloLearn.Constants;
using VoloLearn.DataBase;
using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Repository
{
    public class SchoolCourseRepository : BaseRepository<SchoolCourse>, ISchoolCourseRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public SchoolCourseRepository(VoloLearnDbContext context, UserRepository userRepository, RoleRepository roleRepository) : base(context)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Guid> CreateCourseAsync(Guid userid, SchoolCourse schoolCourse)
        {
            var founded = await _userRepository.GetByIdAsync(userid);
            var schoolRole = await _roleRepository.GetByNameAsync(DefaultRoleName.SchoolName);

            if (founded.Role.Id != schoolRole.Id)
            {
                throw new Exception("You can't create Assigment");
            }

            schoolCourse.CreateById = founded;
            var result = await CreateAsync(schoolCourse);

            SaveAsync();
            return result;
        }


    }
}

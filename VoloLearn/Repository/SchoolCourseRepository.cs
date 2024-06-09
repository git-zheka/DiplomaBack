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

        public SchoolCourseRepository(VoloLearnDbContext context, IUserRepository userRepository, IRoleRepository roleRepository) : base(context)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Guid> CreateCourseAsync(Guid userid, SchoolCourse schoolCourse)
        {
            var founded = await _userRepository.GetByIdAsync(userid);
            var schoolRole = await _roleRepository.GetByNameAsync(DefaultRoleName.SchoolName);

            if (founded.RoleId != schoolRole.Id)
            {
                throw new Exception("You can't create Course");
            }

            schoolCourse.CreatedById = founded.Id;
            var result = await CreateAsync(schoolCourse);

            await SaveAsync();
            return result;
        }


    }
}

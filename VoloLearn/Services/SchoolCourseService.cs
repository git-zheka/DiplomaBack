using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Services
{
    public class SchoolCourseService
    {
        private readonly ISchoolCourseRepository _schoolCourseRepository;

        public SchoolCourseService(ISchoolCourseRepository schoolCourseRepository)
        {
            _schoolCourseRepository = schoolCourseRepository;
        }


/*        public async Task<Guid> CreateCourse()
        {
            return await 
        }*/
    }
}

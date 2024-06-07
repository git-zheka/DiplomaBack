using VoloLearn.Models.Entities;
using VoloLearn.Models.Service;
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Services
{
    public class SchoolCourseService : ISchoolCourseService
    {
        private readonly ISchoolCourseRepository _schoolCourseRepository;

        public SchoolCourseService(ISchoolCourseRepository schoolCourseRepository)
        {
            _schoolCourseRepository = schoolCourseRepository;
        }


        public async Task<Guid> CreateCourseAsync(CreateSchoolCourseModel model)
        {

            var course = new SchoolCourse
            {
                Logo = model.Logo,
                Price = model.Price,
                Description = model.Description
            };

            return await _schoolCourseRepository.CreateCourseAsync(model.CreateById, course);
        }


    }
}

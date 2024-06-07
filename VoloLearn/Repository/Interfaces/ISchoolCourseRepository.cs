using VoloLearn.Models.Entities;

namespace VoloLearn.Repository.Interfaces
{
    public interface ISchoolCourseRepository : IBaseRepository<SchoolCourse>
    {
        Task<Guid> CreateCourseAsync(Guid userid, SchoolCourse schoolCourse);
    }
}

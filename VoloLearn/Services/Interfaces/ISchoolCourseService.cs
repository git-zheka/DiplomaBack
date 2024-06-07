using VoloLearn.Models.Entities;
using VoloLearn.Models.Service;

namespace VoloLearn.Services.Interfaces
{
    public interface ISchoolCourseService
    {
        Task<Guid> CreateCourseAsync(CreateSchoolCourseModel model);
    }
}

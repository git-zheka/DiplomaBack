using VoloLearn.Models.Entities;

namespace VoloLearn.Models.Service
{
    public class CreateSchoolCourseModel
    {
        public int Price { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public Guid CreateById { get; set; }
    }
}

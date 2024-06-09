namespace VoloLearn.Models.Entities
{
    public class SchoolCourse : BaseEntity
    {
        public int Price { get; set; }
        public string Logo { get; set; }
        public string Description { get ; set; }
        public User CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
    }
}


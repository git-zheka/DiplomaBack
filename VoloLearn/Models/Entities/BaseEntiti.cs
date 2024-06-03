namespace VoloLearn.Models.Entities
{
    public abstract class BaseEntiti
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

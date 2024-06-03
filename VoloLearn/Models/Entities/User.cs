namespace VoloLearn.Models.Entities
{
    public class User : BaseEntiti
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get ; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}

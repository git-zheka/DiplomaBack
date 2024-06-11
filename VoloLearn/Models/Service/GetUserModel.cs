using VoloLearn.Models.Entities;

namespace VoloLearn.Models.Service
{
    public class GetUserModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string BearerToken { get; set; }

    }
}

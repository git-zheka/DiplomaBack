namespace VoloLearn.Models.Entities
{
    public class UserScore : BaseEntiti
    {
        public int Score { get; set; }

        public User Visitor { get; set; }

        public Assignment assigment { get; set; }

    }
}

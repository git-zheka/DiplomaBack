using VoloLearn.Models.Enum;

namespace VoloLearn.Models.Entities
{
    public class AssimnetVisitor : BaseEntiti
    {
        public User User { get; set; }

        public Assignment Assignment { get; set; }

        public DateTime? VisitDate { get; set; } 

        public AssignmentVisitStatus Status { get; set; } = AssignmentVisitStatus.NonComfirm;

    }
}

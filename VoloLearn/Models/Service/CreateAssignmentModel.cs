namespace VoloLearn.Models.Service;

public class CreateAssignmentModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime EventDate { get; set; }
    public int Goal { get; set; }
    public int Reward { get; set; }
    public Guid UserId { get; set; }
}
namespace VoloLearn.Models.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }

    public bool IsSuperUser { get; set; }
}
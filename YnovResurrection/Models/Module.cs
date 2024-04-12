namespace YnovResurrection.Models;

public class Module : IModel
{
    public string Id { get; set; }

    public School School { get; set; }

    public string Name { get; set; }

    public int TotalHours { get; set; }

    public User Teacher { get; set; }

    public StudentGroup StudentGroup { get; set; }

    public ICollection<Course> Courses { get; set; }

    public string? NeededEquipment { get; set; }

    public bool IsRemote { get; set; }

    public bool AllowSharedRoom { get; set; }
}

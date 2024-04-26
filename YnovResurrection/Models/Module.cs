using System.ComponentModel.DataAnnotations.Schema;

namespace YnovResurrection.Models;

[Table("Modules")]
public class Module : IModel
{
    public string Id { get; set; }

    public School School { get; set; }

    public string Name { get; set; }

    public int TotalHours { get; set; }

    public User Teacher { get; set; }

    public StudentGroup StudentGroup { get; set; }

    public ICollection<Course> Courses { get; set; }

    public string? NeededEquipment { get; set; } = null;

    public bool IsRemote { get; set; } = false;

    public bool AllowSharedRoom { get; set; } = false;

    public override String ToString() => Name;
}

namespace YnovResurrection.Models;

public class Module(
    string id,
    School school,
    string name,
    int totalHours,
    User teacher,
    StudentGroup studentGroup,
    ICollection<Course> courses,
    string? neededEquipment=null,
    bool isRemote=false,
    bool allowSharedRoom=false)
    : IModel
{
    public string Id { get; set; } = id;

    public School School { get; set; } = school;

    public string Name { get; set; } = name;

    public int TotalHours { get; set; } = totalHours;

    public User Teacher { get; set; } = teacher;

    public StudentGroup StudentGroup { get; set; } = studentGroup;

    public ICollection<Course> Courses { get; set; } = courses;

    public string? NeededEquipment { get; set; } = neededEquipment;

    public bool IsRemote { get; set; } = isRemote;

    public bool AllowSharedRoom { get; set; } = allowSharedRoom;
}

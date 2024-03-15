namespace YnovResurrection.Models;

public class Course : IModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<StudentGroup> StudentGroups { get; set; }
    public bool IsRemote { get; set; }
    public User Teacher { get; set; }
    public string EquipmentNeeds { get; set; }
    public bool AllowSharedRoom { get; set; }
}

public class CourseEvent
{
    public int Id { get; set; }
    public Course Course { get; set; }
    public Room Room { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
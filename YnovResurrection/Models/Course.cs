namespace YnovResurrection.Models;

public class Course : IModel
{
    public string Id { get; set; }

    public Module Module { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool IsRemote { get; set; }

    public Room? Room { get; set; }

}

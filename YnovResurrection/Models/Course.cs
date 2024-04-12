using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Course(string id, Module module, DateTime startTime, DateTime endTime, Room? room=null, bool isRemote=false)
    : IModel
{
    public string Id { get; set; } = id;

    public Module Module { get; set; } = module;

    [Required]
    public DateTime StartTime { get; set; } = startTime;

    [Required]
    public DateTime EndTime { get; set; } = endTime;

    [Required]
    public Room? Room { get; set; } = room;

    public bool IsRemote { get; set; } = isRemote;
}

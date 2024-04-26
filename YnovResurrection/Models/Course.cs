using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YnovResurrection.Models;

[Table("Courses")]
public class Course
    : IModel
{
    public string Id { get; set; }

    public Module Module { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public Room? Room { get; set; } = null;

    public bool IsRemote { get; set; } = false;
}

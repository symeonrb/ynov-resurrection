using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Course : IModel
{

    [Key]
    public string Id { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public bool IsRemote { get; set; }

    public ICollection<Room> Rooms { get; set; }

}
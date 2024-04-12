using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace YnovResurrection.Models;

public class Course : IModel
{
    public string Id { get; set; }

    public Module Module { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public Room? Room { get; set; }

    public bool IsRemote { get; set; }

    public override String ToString() => StartTime.ToString(CultureInfo.CurrentCulture);
}

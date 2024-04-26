using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YnovResurrection.Models;

[Table("Buildings")]
public class Building : IModel
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public School School { get; set; }

    public ICollection<Room> Rooms { get; set; }

    public override String ToString() => Address;
}

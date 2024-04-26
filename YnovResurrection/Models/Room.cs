using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YnovResurrection.Models;

[Table("Rooms")]
public class Room
    : IModel
{
    [Key]
    public string Id { get; set; }

    public Building Building { get; set; }

    public string Name { get; set; }

    public ICollection<Equipment> Equipments { get; set; }

    /// <summary>
    ///  This string is a helper text for new students, so that they can find this room
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// This string is used to know if this room is accessible to people with disabilities
    /// </summary>
    public string? Accessibility { get; set; }

    public int SeatsCount
    {
        get
        {
            var tables1Person = Equipments.Count(e => e.Type == Equipment.Table1PersonType);
            var tables2People = Equipments.Count(e => e.Type == Equipment.Table2PeopleType);
            var seatsFromTables = tables1Person + (tables2People * 2);

            var chairs = Equipments.Count(e => e.Type == Equipment.ChairType);

            return Math.Min(seatsFromTables, chairs);
        }
    }
}

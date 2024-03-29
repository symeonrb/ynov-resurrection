using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Room(
    string id,
    Building building,
    string name,
    ICollection<Equipment> equipments,
    string? location,
    string? accessibility
    )
    : IModel
{
    [Key]
    public string Id { get; set; } = id;

    public Building Building { get; set; } = building;

    public string Name { get; set; } = name;

    public ICollection<Equipment> Equipments { get; set; } = equipments;

    /// <summary>
    ///  This string is a helper text for new students, so that they can find this room
    /// </summary>
    public string? Location { get; set; } = location;

    /// <summary>
    /// This string is used to know if this room is accessible to people with disabilities
    /// </summary>
    public string? Accessibility { get; set; } = accessibility;

    public int SeatsCount { get
        {
            var tables1Person = Equipments.Count(e => e.Type == Equipment.Table1PersonType);
            var tables2People = Equipments.Count(e => e.Type == Equipment.Table2PeopleType);
            var seatsFromTables = tables1Person + (tables2People * 2);

            var chairs = Equipments.Count(e => e.Type == Equipment.ChairType);

            return Math.Min(seatsFromTables, chairs);
        }
    }
}

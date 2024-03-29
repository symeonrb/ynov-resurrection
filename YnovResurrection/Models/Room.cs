using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Room : IModel
{

    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    /// <summary>
    ///  This string is a helper text for new students, so that they can find this room
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// This string is used to know if this room is accessible to people with disabilities
    /// </summary>
    public string Accessibility { get; set; }

    public Building Building { get; set; }

    public ICollection<Equipment> Equipments { get; set; }

}

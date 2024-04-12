using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Building(string id, string address, School school, ICollection<Room> rooms)
    : IModel
{
    [Key]
    public string Id { get; set; } = id;

    [Required]
    public string Address { get; set; } = address;

    public School School { get; set; } = school;

    public ICollection<Room> Rooms { get; set; } = rooms;
}

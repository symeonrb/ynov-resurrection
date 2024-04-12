using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class School(
    string id,
    string name,
    ICollection<User> admins,
    ICollection<User> teachers,
    ICollection<Building> buildings)
    : IModel
{
    [Key]
    public string Id { get; set; } = id;

    [Required]
    public string Name { get; set; } = name;

    // This is a temporary authorization implementation.
    // What is needed is a table Authorizations with a User, a Building and a Role.
    public ICollection<User> Admins { get; set; } = admins;

    public ICollection<User> Teachers { get; set; } = teachers;

    public ICollection<Building> Buildings { get; set; } = buildings;
}

using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class School : IModel
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    // This is a temporary authorization implementation.
    // What is needed is a table Authorizations with a User, a Building and a Role.
    public ICollection<User> Admins { get; set; }

    public ICollection<User> Teachers { get; set; }

    public ICollection<Building> Buildings { get; set; }

    public override String ToString() => Name;
}

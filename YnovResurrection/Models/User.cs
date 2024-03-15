using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class User : IModel
{
    [Key]
    public string Id { get; set; }

    public string Username { get; set; }

    // This is a temporary authorization implementation.
    // What is needed is a table Authorizations with a User, a Building and a Role.
    public bool IsSuperAdmin { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public ICollection<StudentGroup> StudentGroups { get; set; }
}

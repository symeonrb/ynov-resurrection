using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class User(
    string id,
    string firstName,
    string lastName,
    string? email,
    string? password,
    bool isSuperAdmin,
    ICollection<StudentGroup> studentGroups)
    : IModel
{
    [Key]
    public string Id { get; set; } = id;

    public string FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;

    public string? Email { get; set; } = email;

    public string? Password { get; set; } = password;

    // This is a temporary authorization implementation.
    // What is needed is a table Authorizations with a User, a Building and a Role.
    public bool IsSuperAdmin { get; set; } = isSuperAdmin;

    public ICollection<StudentGroup> StudentGroups { get; set; } = studentGroups;
}

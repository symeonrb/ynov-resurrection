using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class StudentGroup(string id, string name, ICollection<User> students) : IModel
{
    [Key]
    public string Id { get; set; } = id;

    public string Name { get; set; } = name;

    public ICollection<User> Students { get; set; } = students;
}

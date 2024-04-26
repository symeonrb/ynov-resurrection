using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class StudentGroup : IModel
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    [Required] public School School { get; set; }

    public ICollection<User> Students { get; set; }

    public override String ToString() => Name;
}

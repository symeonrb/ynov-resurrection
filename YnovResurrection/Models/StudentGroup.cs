using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YnovResurrection.Models;

[Table("StudentGroups")]
public class StudentGroup : IModel
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    public ICollection<User> Students { get; set; }
}

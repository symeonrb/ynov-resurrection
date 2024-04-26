using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YnovResurrection.Models;

[Table("Equipments")]
public class Equipment : IModel
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public string? Tags { get; set; }

    public const string ChairType = "chair";
    public const string Table1PersonType = "table1person";
    public const string Table2PeopleType = "table2people";

    public override String ToString() => Type;
}

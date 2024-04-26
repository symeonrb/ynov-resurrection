using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YnovResurrection.Models;

[Table("Equipments")]
public class Equipment(string id, string type, string? tags) : IModel
{
    [Key]
    public string Id { get; set; } = id;

    [Required]
    public string Type { get; set; } = type;

    [Required]
    public string? Tags { get; set; } = tags;

    public const string ChairType = "chair";
    public const string Table1PersonType = "table1person";
    public const string Table2PeopleType = "table2people";
}

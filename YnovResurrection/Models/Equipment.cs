using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

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
}

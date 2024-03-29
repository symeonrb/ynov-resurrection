using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Equipment(string id, string type, string? tags) : IModel
{
    [Key]
    public string Id { get; set; } = id;

    public string Type { get; set; } = type;

    public string? Tags { get; set; } = tags;

    public const string ChairType = "chair";
    public const string Table1PersonType = "table1person";
    public const string Table2PeopleType = "table2people";
}

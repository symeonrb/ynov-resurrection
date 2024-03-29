using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Equipment : IModel
{

    [Key]
    public string Id { get; set; }

    public string Type { get; set; }

    public string Tags { get; set; }

    public static string chairType = "chair";
    public static string table1PersonType = "table1person";
    public static string table2PeopleType = "table2people";
}

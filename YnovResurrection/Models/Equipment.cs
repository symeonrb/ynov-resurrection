using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Equipment : IModel
{

    [Key]
    public string Id { get; set; }

    public string Type { get; set; }

    public string Tags { get; set; }

}
using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Course : IModel
{

    [Key]
    public string Id { get; set; }

}
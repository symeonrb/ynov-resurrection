using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Course : IModel
{
    
    [Key]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public User Teacher { get; set; }
    
    public StudentGroup StudentGroup { get; set; }
    
}
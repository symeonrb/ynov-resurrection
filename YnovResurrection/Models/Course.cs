using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Course
{
    
    [Key]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public User Teacher { get; set; }
    
    public StudentGroup StudentGroup { get; set; }
    
}
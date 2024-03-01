using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class User : IModel
{
    
    [Key]
    public string Id { get; set; }
    
    public string Username { get; set; }
    
    public bool IsSuperAdmin { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public ICollection<Course> Courses { get; set; }
    
}
using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class User : IModel
{
    
    [Key]
    public string Id { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public bool IsSuperAdmin { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public ICollection<Module> Modules { get; set; }
    
}
using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class School : IModel
{
    
    [Key]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<User> Admins { get; set; }
    
    public ICollection<User> Teachers { get; set; }
    
    public ICollection<Building> Buildings { get; set; }
    
}
using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Building
{
    
    [Key]
    public string Id { get; set; }
    
    public string Address { get; set; }
    
    public int SchoolId { get; set; }
    public School School { get; set; }
    
}
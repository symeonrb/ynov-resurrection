using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Building : IModel
{
    
    [Key]
    public string Id { get; set; }
    
    public string Address { get; set; }
    
    public School School { get; set; }
    
    public ICollection<Room> Rooms { get; set; }
    
}
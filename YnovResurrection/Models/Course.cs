using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Course : IModel
{
    
    [Key]
    public string Id { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public bool IsRemote { get; set; }
    
}
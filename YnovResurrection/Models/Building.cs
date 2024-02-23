namespace YnovResurrection.Models;

public class Building
{
    
    public string Id { get; set; }
    
    public string Address { get; set; }
    
    public int SchoolId { get; set; }
    public School School { get; set; }
    
}
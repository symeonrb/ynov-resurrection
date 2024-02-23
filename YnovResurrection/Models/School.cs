namespace YnovResurrection.Models;

public class School
{
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<User> Admins { get; set; }
    
    public ICollection<User> Teachers { get; set; }
    
    public ICollection<Room> Rooms { get; set; }
    
}
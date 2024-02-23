namespace YnovResurrection.Models;

public class StudentGroup
{
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public  ICollection<User> Students { get; set; }
    
}
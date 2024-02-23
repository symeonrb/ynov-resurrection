namespace YnovResurrection.Models;

public class Room
{
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Location { get; set; }
    
    public string Accessibility { get; set; }
    
    public Building Building { get; set; }
    
    public ICollection<Equipment> Equipments { get; set; }
    
}
namespace YnovResurrection.Models;

public class Module : IModel
{
    public string Id { get; set; }
    
    public bool IsRemote { get; set; }
    
    public string Name { get; set; }
    
    public User Teacher { get; set; }
    
    public StudentGroup StudentGroup { get; set; }
    
    public string NeededEquipment { get; set; }
    
    public bool AllowSharedRoom { get; set; }
    
    public int Hours { get; set; }
    
}
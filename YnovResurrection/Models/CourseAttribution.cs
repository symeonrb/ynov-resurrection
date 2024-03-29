namespace YnovResurrection.Models;

public class CourseAttribution : IModel
{
    public string Id { get; set; }
    
    public int CourseId { get; set; }
    
    public int RoomId { get; set; }
    
}
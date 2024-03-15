using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class CourseService : AService
{
    private CourseService()
    {
    }

    public static CourseService Instance { get; } = new();

    public ICollection<Course> List()
    {
        return _appDb.Courses.ToList();
    }
    
}

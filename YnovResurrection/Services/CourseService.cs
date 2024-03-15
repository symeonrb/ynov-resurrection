using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class CourseService : AService
{

    /// <summary>
    /// Create a course with the given parameters
    /// </summary>
    public void CreateCourse(Module module)
    {
        var course = new Course();
        
        ApplyId(ref course);

        _appDb.Courses.Add(course);
        Flush();
    }

    public ICollection<Course> List()
    {
        return _appDb.Courses.ToList();
    }
    
}
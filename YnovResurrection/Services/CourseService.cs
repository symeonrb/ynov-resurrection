using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class CourseService : AService
{

    /// <summary>
    /// Create a course with the given parameters
    /// </summary>
    /// <param name="name"></param>
    /// <param name="teacher"></param>
    /// <param name="studentGroup"></param>
    public void CreateCourse(string name, User teacher, StudentGroup studentGroup)
    {
        var course = new Course()
        {
            Name = name,
            StudentGroup = studentGroup
        };
        
        ApplyId(ref course);

        _appDb.Courses.Add(course);
        Flush();
    }

    /// <summary>
    /// Set course teacher
    /// </summary>
    /// <param name="course"></param>
    /// <param name="teacherId"></param>
    /// <exception cref="Exception"></exception>
    public void SetTeacher(Course course, string teacherId)
    {
        var user = _appDb.Users.SingleOrDefault(user => user.Id == teacherId);

        if (user == null)
        {
            throw new Exception("Teacher were not found");
        }

        course.Teacher = user;
        Flush();
    }

    /// <summary>
    /// Find the specified course
    /// </summary>
    /// <param name="name"></param>
    /// <param name="studentGroup"></param>
    /// <returns></returns>
    public Course? FindCourse(string name, StudentGroup studentGroup)
    {
        return _appDb.Courses.SingleOrDefault(c => c.Name == name && c.StudentGroup == studentGroup);
    }

    public ICollection<Course> List()
    {
        return _appDb.Courses.ToList();
    }
    
}
using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class CourseService : AService
{

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
    
}
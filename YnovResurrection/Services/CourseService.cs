using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class CourseService : AService
{

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
using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class ModuleService : AService
{

    /// <summary>
    /// Set module teacher
    /// </summary>
    /// <param name="module">Module</param>
    /// <param name="teacherId">User id of teacher</param>
    /// <exception cref="Exception">In case teacher doesn't exist</exception>
    public void SetTeacher(Module module, string teacherId) //TODO: rework this
    {
        var teacher = _appDb.Users.SingleOrDefault(user => user.Id == teacherId);

        if (teacher == null)
        {
            throw new Exception("Teacher were not found");
        }

        SetTeacher(module, teacher);
    }

    /// <summary>
    /// Set module teacher
    /// </summary>
    /// <param name="module">Module</param>
    /// <param name="teacher">Teacher</param>
    public void SetTeacher(Module module, User teacher)
    {
        module.Teacher = teacher;
        Flush();
    }
    
}
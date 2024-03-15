using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class ModuleService : AService
{

    /// <summary>
    /// Create a module, and return it
    /// </summary>
    /// <param name="isRemote"></param>
    /// <param name="name"></param>
    /// <param name="teacher"></param>
    /// <param name="studentGroups"></param>
    /// <param name="neededEquipments"></param>
    /// <param name="allowSharedRoom"></param>
    public Module CreateModule(
        bool isRemote,
        string name,
        User teacher,
        ICollection<StudentGroup> studentGroups,
        string neededEquipments,
        bool allowSharedRoom
    )
    {
        var module = new Module
        {
            IsRemote = isRemote,
            Name = name,
            Teacher = teacher,
            StudentGroups = studentGroups,
            NeededEquipment = neededEquipments,
            AllowSharedRoom = allowSharedRoom
        };

        _appDb.Modules.Add(module);
        Flush();

        return module;
    }


    /// <summary>
    /// Set module teacher
    /// </summary>
    /// <param name="module">Module</param>
    /// <param name="teacherId">User id of teacher</param>
    /// <exception cref="Exception">In case teacher doesn't exist</exception>
    public void SetTeacher(Module module, string teacherId)
    {
        var teacher = _appDb.Users.SingleOrDefault(user => user.Id == teacherId);

        if (teacher == null)
        {
            throw new Exception("Teacher were not found");
        }

        module.Teacher = teacher;
        Flush();
    }

    /// <summary>
    /// Find the specified course
    /// </summary>
    /// <param name="name"></param>
    /// <param name="studentGroup"></param>
    /// <returns></returns>
    public IQueryable<Module> ModulesOfStudentGroup(StudentGroup studentGroup)
    {
        return _appDb.Modules.Where(m => m.StudentGroups.Contains(studentGroup));
    }

}

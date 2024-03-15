using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class ModuleService : AService
{

    /// <summary>
    /// Create a module, and return it
    /// </summary>
    /// <param name="isRemote"></param>
    /// <param name="name"></param>
    /// <param name="neededEquipments"></param>
    /// <param name="allowSharedRoom"></param>
    public Module CreateModule(bool isRemote, string name, string neededEquipments, bool allowSharedRoom)
    {
        var module = new Module
        {
            IsRemote = isRemote,
            Name = name,
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
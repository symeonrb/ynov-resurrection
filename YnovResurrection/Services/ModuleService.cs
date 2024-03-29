using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class ModuleService : AService
{
    private ModuleService()
    {
        var studentGroups = StudentGroupService.Instance.List();
        var bachelor1 = studentGroups.ElementAt(0);
        var bachelor2 = studentGroups.ElementAt(1);
        var studyingFrench = studentGroups.ElementAt(2);
        var users = UserService.Instance.List();

        var banjo = new Module
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Banjo",
            StudentGroups = [ bachelor1 ],
            Teacher = users.First((u) => u.Username == "TeacherBanjo"),
        };
        var dj = new Module
        {
            Id = Guid.NewGuid().ToString(),
            Name = "DJ",
            StudentGroups = [ bachelor2 ],
            Teacher = users.First((u) => u.Username == "TeacherDJ"),
        };
        var guitareb1 = new Module
        {
            Id = Guid.NewGuid().ToString(),
            Name = "GuitareB1",
            StudentGroups = [ bachelor1 ],
            Teacher = users.First((u) => u.Username == "TeacherGuitare"),
        };
        var guitareb2 = new Module
        {
            Id = Guid.NewGuid().ToString(),
            Name = "GuitareB2",
            StudentGroups = [ bachelor2 ],
            Teacher = users.First((u) => u.Username == "TeacherGuitare"),
        };
        var french = new Module
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Français",
            StudentGroups = [ studyingFrench ],
            Teacher = users.First((u) => u.Username == "TeacherFrench"),
        };

        _fakeData = [ banjo, dj, guitareb1, guitareb2, french ];
    }

    public static ModuleService Instance { get; } = new();

    private readonly List<Module> _fakeData;

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
    /// Find the modules assignated to a StudentGroup
    /// </summary>
    /// <param name="name"></param>
    /// <param name="studentGroup"></param>
    /// <returns></returns>
    public IQueryable<Module> ModulesOfStudentGroup(StudentGroup studentGroup)
    {
        return _appDb.Modules.Where(m => m.StudentGroups.Contains(studentGroup));
    }

}

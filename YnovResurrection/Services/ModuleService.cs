using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class ModuleService : AService
{
    private ModuleService()
    {
        var schools = SchoolService.Instance.List();
        var musicHouse = schools.ElementAt(0);
        var studentGroups = StudentGroupService.Instance.List();
        var bachelor1 = studentGroups.ElementAt(0);
        var bachelor2 = studentGroups.ElementAt(1);
        var studyingFrench = studentGroups.ElementAt(2);
        var users = UserService.Instance.List();

        CreateModule(
            school: musicHouse,
            name: "Banjo",
            totalHours: 3,
            teacher: users.First((u) => u.FirstName == "TeacherBanjo"),
            studentGroup: bachelor1
        );
        CreateModule(
            school: musicHouse,
            name: "DJ",
            totalHours: 3,
            teacher: users.First((u) => u.FirstName == "TeacherDJ"),
            studentGroup: bachelor2
        );
        CreateModule(
            school: musicHouse,
            name: "GuitareB1",
            totalHours: 3,
            teacher: users.First((u) => u.FirstName == "TeacherGuitar"),
            studentGroup: bachelor1
        );
        CreateModule(
            school: musicHouse,
            name: "GuitareB2",
            totalHours: 3,
            teacher: users.First((u) => u.FirstName == "TeacherGuitar"),
            studentGroup: bachelor2
        );
        CreateModule(
            school: musicHouse,
            name: "Français",
            totalHours: 3,
            teacher: users.First((u) => u.FirstName == "TeacherFrench"),
            studentGroup: studyingFrench
        );
    }

    public static ModuleService Instance { get; } = new();

    private readonly List<Module> _fakeData = [];

    /// <summary>
    /// Create a module, and return it
    /// </summary>
    /// <param name="school"></param>
    /// <param name="name"></param>
    /// <param name="totalHours"></param>
    /// <param name="teacher"></param>
    /// <param name="studentGroup"></param>
    /// <param name="neededEquipments"></param>
    /// <param name="isRemote"></param>
    /// <param name="allowSharedRoom"></param>
    public void CreateModule(
        School school,
        string name,
        int totalHours,
        User teacher,
        StudentGroup studentGroup,
        string neededEquipments="",
        bool isRemote=false,
        bool allowSharedRoom=false
    )
    {
        _fakeData.Add(
            new Module(
                id: Guid.NewGuid().ToString(),
                school: school,
                name: name,
                totalHours: totalHours,
                teacher: teacher,
                studentGroup: studentGroup,
                courses: [],
                neededEquipment: neededEquipments,
                isRemote: isRemote,
                allowSharedRoom: allowSharedRoom
            )
        );

        // TODO :
        // var module = new Module
        // {
        //     School = school,
        //     IsRemote = isRemote,
        //     Name = name,
        //     Teacher = teacher,
        //     StudentGroup = studentGroup,
        //     NeededEquipment = neededEquipments,
        //     AllowSharedRoom = allowSharedRoom
        // };
        //
        // _appDb.Modules.Add(module);
        // Flush();
        //
        // return module;
    }

    public ICollection<Module> List()
    {
        return _fakeData; // TODO : _appDb.Equipments.ToList();
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
    /// <param name="studentGroup"></param>
    /// <returns></returns>
    public IQueryable<Module> ModulesOfStudentGroup(StudentGroup studentGroup)
    {
        return _appDb.Modules.Where(m => m.StudentGroup == studentGroup);
    }

}

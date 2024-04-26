using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class StudentGroupService : AService
{
    private StudentGroupService()
    {
        var schools = SchoolService.Instance.List();

        var s1 = schools.ElementAt(0);
        CreateStudentGroup(name: "Bachelor 1", school: s1);
        CreateStudentGroup(name: "Bachelor 2", school: s1);
        CreateStudentGroup(name: "Students learning French", school: s1);
    }

    public static StudentGroupService Instance { get; } = new();

    private readonly List<StudentGroup> _fakeData = [];

    /// <summary>
    /// Add the specified student to the group
    /// </summary>
    /// <param name="group"></param>
    /// <param name="student"></param>
    public void AddStudent(StudentGroup group, User student)
    {
        group.Students.Add(student);
        Flush();
    }

    /// <summary>
    /// Create and return a new student group
    /// </summary>
    /// <param name="name"></param>
    /// <param name="school"></param>
    /// <returns></returns>
    public StudentGroup CreateStudentGroup(string name, School school)
    {
        var studentGroup = new StudentGroup
        {
            Name = name,
            School = school,
            Students = []
        };
        ApplyId(studentGroup);

        _fakeData.Add(studentGroup);
        // TODO : replace by this
        // _appDb.Buildings.Add(studentGroup);
        // Flush();

        return studentGroup;
    }

    public IEnumerable<StudentGroup> FromSchoolId(string schoolId)
    {
        return Instance._fakeData.Where(sg => sg.School.Id == schoolId);
    }

    public ICollection<StudentGroup> List()
    {
        return _fakeData; // TODO : _appDb.StudentGroups.ToList();
    }
    
}

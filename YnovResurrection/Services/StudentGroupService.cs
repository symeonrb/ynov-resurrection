using System.Collections;
using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class StudentGroupService : AService
{
    private StudentGroupService()
    {
        CreateStudentGroup(name: "Bachelor 1");
        CreateStudentGroup(name: "Bachelor 2");
        CreateStudentGroup(name: "Students learning French");
    }

    public static StudentGroupService Instance { get; } = new();

    private readonly List<StudentGroup> _fakeData = [];

    /// <summary>
    /// Create and return a new student group
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public StudentGroup CreateStudentGroup(string name)
    {
        var studentGroup = new StudentGroup
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Students = []
        };
        ApplyId(ref studentGroup);

        _fakeData.Add(studentGroup);
        // TODO : replace by this
        // _appDb.Buildings.Add(studentGroup);
        // Flush();

        return studentGroup;
    }
    
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

    public ICollection<StudentGroup> List()
    {
        return _fakeData; // TODO : _appDb.StudentGroups.ToList();
    }
    
}

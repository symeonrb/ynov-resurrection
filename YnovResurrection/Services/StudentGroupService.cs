using System.Collections;
using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class StudentGroupService : AService
{
    private StudentGroupService()
    {
        var users = UserService.Instance.List();
        _fakeData =
        [
            new StudentGroup
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Bachelor 1",
                Students = users.Take(new Range(0, 7)).ToList(),
            },
            new StudentGroup
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Bachelor 2",
                Students = users.Take(new Range(8, 11)).ToList(),
            },
            new StudentGroup
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Students learning French",
                Students = users.Take(new Range(4, 9)).ToList(),
            },
            new StudentGroup
            {
                Id = Guid.NewGuid().ToString(),
                Name = "All students",
                Students = users,
            },
        ];
    }

    public static StudentGroupService Instance { get; } = new();

    private readonly List<StudentGroup> _fakeData;

    /// <summary>
    /// Create and return a new student group
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public StudentGroup CreateStudentGroup(string name)
    {
        var group = new StudentGroup
        {
            Name = name
        };
        
        ApplyId(ref group);
        _appDb.StudentGroups.Add(group);
        
        Flush();

        return group;
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

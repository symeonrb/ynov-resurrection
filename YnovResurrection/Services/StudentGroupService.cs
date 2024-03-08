using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class StudentGroupService : AService
{

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
    
}
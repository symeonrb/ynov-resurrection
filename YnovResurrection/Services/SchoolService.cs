using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class SchoolService : AService
{
    private SchoolService()
    {
        CreateSchool(name: "MusicHouse");
        CreateSchool(name: "NobodyNovy"); // unused school
    }

    public static SchoolService Instance { get; } = new();

    private readonly List<School> _fakeData = [];

    public School CreateSchool(string name)
    {
        var school = new School
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Admins = [],
            Teachers = [],
            Buildings = []
        };
        _fakeData.Add(school);
        return school;

        // TODO :
        // var school = new School
        // {
        //     Id = Guid.NewGuid().ToString(),
        //     Name: name
        // };
        //
        // ApplyId(ref school);
        //
        // _appDb.Schools.Add(school);
        // Flush();
    }

    public ICollection<School> List()
    {
        return _fakeData; // TODO : _appDb.Schools.ToList();
    }
    
}

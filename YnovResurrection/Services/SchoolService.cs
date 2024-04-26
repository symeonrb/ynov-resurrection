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

    public void CreateSchool(string name)
    {
        //_fakeData.Add(
        //    new School(
        //        id: Guid.NewGuid().ToString(),
        //        name: name,
        //        admins: [],
        //        teachers: [],
        //        buildings: []
        //    )
        //);

        var school = new School
        {
            Name = name
        };

        ApplyId(ref school);

        _appDb.Schools.Add(school);
        Flush();
    }

    public ICollection<School> List()
    {
        return _fakeData; // TODO : _appDb.Schools.ToList();
    }

}

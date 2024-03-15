using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class SchoolService : AService
{
    private SchoolService()
    {
        _fakeData =
        [
            new School { Id = Guid.NewGuid().ToString(), Name = "Ynov" },
            new School { Id = Guid.NewGuid().ToString(), Name = "Novy" },
        ];
    }

    public static SchoolService Instance { get; } = new();

    private readonly List<School> _fakeData;

    public ICollection<School> List()
    {
        return _fakeData; // TODO : _appDb.Schools.ToList();
    }
    
}

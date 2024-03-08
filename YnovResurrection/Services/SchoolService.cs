using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class SchoolService : AService
{

    public ICollection<School> List()
    {
        return _appDb.Schools.ToList();
    }
    
}
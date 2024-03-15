using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class BuildingService : AService
{
    private BuildingService()
    {
        var schools = SchoolService.Instance.List();

        var s1 = schools.ElementAt(0);
        var b1 = new Building { Id = Guid.NewGuid().ToString(), Address = "123 Main St", School = s1 };
        var b2 = new Building { Id = Guid.NewGuid().ToString(), Address = "456 Elm St", School = s1 };
        s1.Buildings = [b1, b2];

        var s2 = schools.ElementAt(1);
        var b3 = new Building { Id = Guid.NewGuid().ToString(), Address = "123 Main St", School = s2 };
        s2.Buildings = [b3];

        _fakeData = [ b1, b2, b3 ];
    }

    public static BuildingService Instance { get; } = new();

    private readonly List<Building> _fakeData;

    public void CreateBuilding(string address, School school)
    {
        var building = new Building
        {
            Address = address,
            School = school
        };
        
        ApplyId(ref building);
        _appDb.Buildings.Add(building);
        Flush();
    }

    public ICollection<Building> List()
    {
        return _fakeData; // TODO : _appDb.Buildings.ToList();
    }
    
}

using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class BuildingService : AService
{
    private BuildingService()
    {
        var schools = SchoolService.Instance.List();

        var s1 = schools.ElementAt(0);
        CreateBuilding(address: "1 Swing St", school: s1);
        CreateBuilding(address: "2 Swing St", school: s1);
        s1.Buildings = _fakeData.Where(b => b.School.Id == s1.Id).ToList();

        var s2 = schools.ElementAt(1);
        CreateBuilding(address: "000 Nowhere St", school: s2);
        s2.Buildings = _fakeData.Where(b => b.School.Id == s2.Id).ToList();
    }

    public static BuildingService Instance { get; } = new();

    private readonly List<Building> _fakeData = [];

    public void CreateBuilding(string address, School school)
    {
        _fakeData.Add(
            new Building(
                id: Guid.NewGuid().ToString(),
                address: address,
                school: school,
                rooms: []
            )
        );

        // TODO :
        // var building = new Building
        // {
        //     Address = address,
        //     School = school
        // };
        //
        // ApplyId(ref building);
        // _appDb.Buildings.Add(building);
        // Flush();
    }

    public ICollection<Building> List()
    {
        return _fakeData; // TODO : _appDb.Buildings.ToList();
    }
    
}

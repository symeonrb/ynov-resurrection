using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class BuildingService : AService
{

    public void CreateBuilding(string address, School school)
    {
        var building = new Building
        {
            Address = address,
            School = school
        };
        
        ApplyId(ref building);
        Flush();
    }
    
}
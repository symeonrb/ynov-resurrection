using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class EquipmentService : AService
{

    public Equipment CreateEquipment(string type, string tags)
    {
        var e = new Equipment
        {
            Type = type,
            Tags = tags
        };
        
        ApplyId(ref e);
        _appDb.Equipments.Add(e);
        Flush();

        return e;
    }

    public ICollection<Equipment> List()
    {
        return _appDb.Equipments.ToList();
    }

}
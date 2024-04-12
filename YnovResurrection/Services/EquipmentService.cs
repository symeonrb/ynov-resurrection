using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class EquipmentService : AService
{
    private EquipmentService()
    {
        var rooms = RoomService.Instance.List();

        CreateEquipment(type: Equipment.ChairType);
        CreateEquipment(type: Equipment.Table1PersonType);
        CreateEquipment(type: Equipment.Table2PeopleType);

        var chair = _fakeData.Single(e => e.Type == Equipment.ChairType);
        var table1Person = _fakeData.Single(e => e.Type == Equipment.Table1PersonType);
        var table2People = _fakeData.Single(e => e.Type == Equipment.Table2PeopleType);

        rooms.ElementAt(0).Equipments = [
            chair, chair,
            table2People,
        ];
        rooms.ElementAt(1).Equipments = [
            chair, chair, chair, chair, chair, chair,
            table2People, table2People, table2People,
        ];
        rooms.ElementAt(2).Equipments = [
            chair, chair, chair, chair, chair, chair, chair, chair,
            table1Person, table1Person, table1Person, table1Person,
        ];

        rooms.ElementAt(3).Equipments = [
            chair, chair,
            table2People,
        ];
        rooms.ElementAt(4).Equipments = [
            chair, chair,
            table2People,
        ];

        rooms.ElementAt(5).Equipments = [
            chair, chair, chair, chair, chair, chair, chair, chair, chair, chair, chair, chair, chair, chair,
            table2People, table2People, table2People, table2People, table2People, table2People, table2People,
        ];
    }

    public static EquipmentService Instance { get; } = new();

    private readonly List<Equipment> _fakeData = [];

    public Equipment CreateEquipment(string type, string? tags=null)
    {
        var equipment = new Equipment
        {
            Type = type,
            Tags = tags,
        };
        ApplyId(ref equipment);

        _fakeData.Add(equipment);
        // TODO : replace by this
        // _appDb.Buildings.Add(equipment);
        // Flush();

        return equipment;
    }

    public ICollection<Equipment> List()
    {
        return _fakeData; // TODO : _appDb.Equipments.ToList();
    }

}

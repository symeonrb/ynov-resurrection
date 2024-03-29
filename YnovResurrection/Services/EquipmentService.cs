using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class EquipmentService : AService
{
    private EquipmentService()
    {
        var rooms = RoomService.Instance.List();

        var chair = new Equipment{ Type = Equipment.chairType };
        var table1Person = new Equipment{ Type = Equipment.table1PersonType };
        var table2People = new Equipment{ Type = Equipment.table2PeopleType };

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

        _fakeData = rooms.SelectMany(room => room.Equipments).ToList();
    }

    public static EquipmentService Instance { get; } = new();

    private readonly List<Equipment> _fakeData;

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
        return _fakeData; // TODO : _appDb.Equipments.ToList();
    }

}

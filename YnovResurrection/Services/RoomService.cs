using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class RoomService : AService
{
    private RoomService()
    {
        var buildings = BuildingService.Instance.List();

        var b1 = buildings.ElementAt(0);
        CreateRoom(building: b1, name: "a101");
        CreateRoom(building: b1, name: "a102");
        CreateRoom(building: b1, name: "a103");
        b1.Rooms = _fakeData.Where(r => r.Building.Id == b1.Id).ToList();

        var b2 = buildings.ElementAt(1);
        CreateRoom(building: b2, name: "b101");
        CreateRoom(building: b2, name: "b102");
        b2.Rooms = _fakeData.Where(r => r.Building.Id == b2.Id).ToList();

        var b3 = buildings.ElementAt(2);
        CreateRoom(building: b3, name: "Amphitheater");
        b3.Rooms = _fakeData.Where(r => r.Building.Id == b3.Id).ToList();
    }

    public static RoomService Instance { get; } = new();

    private readonly List<Room> _fakeData = [];

    public Room? FromId(string roomId)
    {
        return Instance._fakeData.SingleOrDefault(r => r.Id == roomId);
    }

    public IEnumerable<Room> FromSchoolId(string schoolId)
    {
        return Instance._fakeData.Where(r => r.Building.School.Id == schoolId);
    }

    public Room CreateRoom(Building building, string name, string? location=null, string? accessibility=null)
    {
        var room = new Room
        {
            Building = building,
            Name = name,
            Equipments = [],
            Location = location,
            Accessibility = accessibility
        };
        ApplyId(room);

        _fakeData.Add(room);
        // TODO : replace by this
        // _appDb.Buildings.Add(room);
        // Flush();

        return room;
    }

    public void DeleteRoom(Room room) => _fakeData.Remove(room);

    /// <summary>
    /// Find the specified room in the building
    /// </summary>
    /// <param name="building"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Room? FindRoom(Building building, string name)
    {
        return _appDb.Rooms.SingleOrDefault(r => (r.Building == building && r.Name == name));
    }

    public ICollection<Room> List()
    {
        return _fakeData; // TODO : _appDb.Rooms.ToList();
    }

    public void UpdateRoom(Room room)
    {
        var index = _fakeData.FindIndex(b => b.Id == room.Id);
        if (index == -1) return;
        _fakeData[index] = room;
    }
    
}

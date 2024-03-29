using System.Numerics;
using System.Runtime.Intrinsics;
using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class RoomService : AService
{
    private RoomService()
    {
        var buildings = BuildingService.Instance.List();

        var b1 = buildings.ElementAt(0);
        var r1 = new Room
        {
            Id = Guid.NewGuid().ToString(),
            Building = b1,
            Name = "a101"
        };
        var r2 = new Room
        {
            Id = Guid.NewGuid().ToString(),
            Building = b1,
            Name = "a102"
        };
        var r3 = new Room
        {
            Id = Guid.NewGuid().ToString(),
            Building = b1,
            Name = "a103"
        };
        b1.Rooms = [r1, r2, r3];

        var b2 = buildings.ElementAt(1);
        var r4 = new Room {
            Id = Guid.NewGuid().ToString(),
            Building = b2,
            Name = "b101",
        };
        var r5 = new Room
        {
            Id = Guid.NewGuid().ToString(),
            Building = b2,
            Name = "b102",
        };
        b2.Rooms = [r4, r5];

        var b3 = buildings.ElementAt(2);
        var r6 = new Room {
            Id = Guid.NewGuid().ToString(),
            Building = b3,
            Name = "Amphitheater",
        };
        b3.Rooms = [r6];

        _fakeData = [ r1, r2, r3, r4, r5, r6 ];
    }

    public static RoomService Instance { get; } = new();

    private readonly List<Room> _fakeData;

    public void CreateRoom(Building building, string name, string location, string accessibility)
    {
        var room = new Room
        {
            Accessibility = accessibility,
            Location = location,
            Name = name,
            
            Building = building
        };

        ApplyId(ref room);

        _appDb.Rooms.Add(room);
        Flush();
    }
    
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
    
}

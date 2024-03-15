using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class RoomService : AService
{

    /// <summary>
    /// Create a room with specified parameters
    /// </summary>
    /// <param name="building"></param>
    /// <param name="name"></param>
    /// <param name="location"></param>
    /// <param name="accessibility"></param>
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
        return _appDb.Rooms.ToList();
    }
    
}
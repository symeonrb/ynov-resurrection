using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class RoomService : AService
{

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
    
}
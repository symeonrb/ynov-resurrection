using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class FakeCourseAttributionService
{
    private FakeCourseAttributionService()
    {
        _fakeData = [];
    }

    public static FakeCourseAttributionService Instance { get; } = new();

    private readonly List<CourseAttribution> _fakeData;

    public ICollection<CourseAttribution> List()
    {
        return _fakeData; // TODO : _appDb.Courses.ToList();
    }

    public static Room? RoomOf(Course course)
    {
        var roomId = Instance._fakeData.SingleOrDefault((ca) => ca.CourseId == course.Id)?.RoomId;
        return roomId == null ? null : RoomService.FromId(roomId);
    }
}

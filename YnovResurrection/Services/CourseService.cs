using System.Diagnostics;
using System.Globalization;
using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class CourseService : AService
{
    private CourseService()
    {
        var modules = ModuleService.Instance.List();

        var banjo = modules.ElementAt(0);
        CreateCourse(
            module: banjo,
            startTime: new DateTime(year: 2024, month: 9, day: 15, hour: 9, minute: 0, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 15, hour: 12, minute: 0, second: 0)
        );
        CreateCourse(
            module: banjo,
            startTime: new DateTime(year: 2024, month: 9, day: 15, hour: 13, minute: 30, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 15, hour: 16, minute: 30, second: 0)
        );
        banjo.Courses = _fakeData.Where(c => c.Module.Id == banjo.Id).ToList();

        var dj = modules.ElementAt(1);
        CreateCourse(
            module: dj,
            startTime: new DateTime(year: 2024, month: 9, day: 15, hour: 9, minute: 0, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 15, hour: 12, minute: 0, second: 0)
        );
        CreateCourse(
            module: dj,
            startTime: new DateTime(year: 2024, month: 9, day: 15, hour: 13, minute: 30, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 15, hour: 16, minute: 30, second: 0)
        );
        dj.Courses = _fakeData.Where(c => c.Module.Id == dj.Id).ToList();

        var guitareb1 = modules.ElementAt(2);
        CreateCourse(
            module: guitareb1,
            startTime: new DateTime(year: 2024, month: 9, day: 16, hour: 9, minute: 0, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 16, hour: 12, minute: 0, second: 0)
        );
        CreateCourse(
            module: guitareb1,
            startTime: new DateTime(year: 2024, month: 9, day: 16, hour: 13, minute: 30, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 16, hour: 16, minute: 30, second: 0)
        );
        guitareb1.Courses = _fakeData.Where(c => c.Module.Id == guitareb1.Id).ToList();

        var guitareb2 = modules.ElementAt(3);
        CreateCourse(
            module: guitareb2,
            startTime: new DateTime(year: 2024, month: 9, day: 17, hour: 9, minute: 0, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 17, hour: 12, minute: 0, second: 0)
        );
        CreateCourse(
            module: guitareb2,
            startTime: new DateTime(year: 2024, month: 9, day: 17, hour: 13, minute: 30, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 17, hour: 16, minute: 30, second: 0)
        );
        guitareb2.Courses = _fakeData.Where(c => c.Module.Id == guitareb2.Id).ToList();

        var french = modules.ElementAt(4);
        CreateCourse(
            module: french,
            startTime: new DateTime(year: 2024, month: 9, day: 17, hour: 9, minute: 0, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 17, hour: 12, minute: 0, second: 0)
        );
        CreateCourse(
            module: french,
            startTime: new DateTime(year: 2024, month: 9, day: 17, hour: 13, minute: 30, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 17, hour: 16, minute: 30, second: 0)
        );
        french.Courses = _fakeData.Where(c => c.Module.Id == french.Id).ToList();

        var eloquence = modules.ElementAt(5);
        CreateCourse(
            module: eloquence,
            startTime: new DateTime(year: 2024, month: 9, day: 17, hour: 13, minute: 30, second: 0),
            endTime: new DateTime(year: 2024, month: 9, day: 17, hour: 16, minute: 30, second: 0)
        );
        eloquence.Courses = _fakeData.Where(c => c.Module.Id == eloquence.Id).ToList();
    }

    public static CourseService Instance { get; } = new();

    private readonly List<Course> _fakeData = [];

    public void AssignRoomToCourse(Course course)
    {
        if (course.Room != null) return;

        var students = course.Module.StudentGroup.Students.Count;
        var bigEnoughRooms = RoomService.Instance.FromSchoolId(course.Module.School.Id).Where((r) => r.SeatsCount >= students).ToList();

        if (bigEnoughRooms.Count == 0) throw new Exception("No room is big enough for this student group");

        var overlapingCourses = Instance.List().Where(c => CoursesOverlap(c, course));
        var occupiedRooms = overlapingCourses.Select(c => c.Room);
        var availibleRooms = bigEnoughRooms.Where(r => !occupiedRooms.Contains(r)).ToList();

        if (availibleRooms.Count == 0) throw new Exception("No matching room is availible during this course");

        course.Room = availibleRooms.First();
    }

    private static bool CoursesOverlap(Course c1, Course c2)
    {
        return c1.StartTime < c2.EndTime && c2.StartTime < c1.EndTime;
    }

    /// <summary>
    /// Create a course with the given parameters
    /// </summary>
    public Course CreateCourse(
        Module module,
        DateTime startTime,
        DateTime endTime,
        bool isRemote=false,
        Room? room = null
    )
    {
        var course = new Course
        {
            Module = module,
            StartTime = startTime,
            EndTime = endTime,
            IsRemote = isRemote,
            Room = room
        };
        ApplyId(course);

        _fakeData.Add(course);
        // TODO : replace by this
        // _appDb.Courses.Add(course);
        // Flush();

        return course;
    }

    public void DeleteCourse(Course course) => _fakeData.Remove(course);

    public ICollection<Course> List() => _fakeData; // TODO : _appDb.Courses.ToList();

    public void UpdateCourse(Course course)
    {
        var index = _fakeData.FindIndex(b => b.Id == course.Id);
        if (index == -1) return;
        _fakeData[index] = course;
    }
}

using System.Globalization;
using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class CourseService : AService
{
    private CourseService()
    {
        var modules = ModuleService.Instance.List();

        var banjo = modules.ElementAt(0);
        banjo.Courses = [
            new Course
            {
                Module = banjo,
                StartTime = new DateTime(year: 2024, month: 9, day: 15, hour: 9, minute: 0, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 15, hour: 12, minute: 0, second: 0),
            },
            new Course
            {
                Module = banjo,
                StartTime = new DateTime(year: 2024, month: 9, day: 15, hour: 13, minute: 30, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 15, hour: 16, minute: 30, second: 0),
            },
        ];
        var dj = modules.ElementAt(1);
        dj.Courses = [
            new Course
            {
                Module = dj,
                StartTime = new DateTime(year: 2024, month: 9, day: 15, hour: 9, minute: 0, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 15, hour: 12, minute: 0, second: 0),
            },
            new Course
            {
                Module = dj,
                StartTime = new DateTime(year: 2024, month: 9, day: 15, hour: 13, minute: 30, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 15, hour: 16, minute: 30, second: 0),
            },
        ];
        var guitareb1 = modules.ElementAt(2);
        guitareb1.Courses = [
            new Course
            {
                Module = guitareb1,
                StartTime = new DateTime(year: 2024, month: 9, day: 16, hour: 9, minute: 0, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 16, hour: 12, minute: 0, second: 0),
            },
            new Course
            {
                Module = guitareb1,
                StartTime = new DateTime(year: 2024, month: 9, day: 16, hour: 13, minute: 30, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 16, hour: 16, minute: 30, second: 0),
            },
        ];
        var guitareb2 = modules.ElementAt(3);
        guitareb2.Courses = [
            new Course
            {
                Module = guitareb2,
                StartTime = new DateTime(year: 2024, month: 9, day: 17, hour: 9, minute: 0, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 17, hour: 12, minute: 0, second: 0),
            },
            new Course
            {
                Module = guitareb2,
                StartTime = new DateTime(year: 2024, month: 9, day: 17, hour: 13, minute: 30, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 17, hour: 16, minute: 30, second: 0),
            },
        ];
        var french = modules.ElementAt(4);
        french.Courses = [
            new Course
            {
                Module = french,
                StartTime = new DateTime(year: 2024, month: 9, day: 17, hour: 9, minute: 0, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 17, hour: 12, minute: 0, second: 0),
            },
            new Course
            {
                Module = french,
                StartTime = new DateTime(year: 2024, month: 9, day: 17, hour: 13, minute: 30, second: 0),
                EndTime =   new DateTime(year: 2024, month: 9, day: 17, hour: 16, minute: 30, second: 0),
            },
        ];

        _fakeData = modules.SelectMany(module => module.Courses).ToList();
    }

    public static CourseService Instance { get; } = new();

    private readonly List<Course> _fakeData;

    /// <summary>
    /// Create a course with the given parameters
    /// </summary>
    public void CreateCourse(Module module)
    {
        var course = new Course();
        
        ApplyId(ref course);

        _appDb.Courses.Add(course);
        Flush();
    }

    public ICollection<Course> List()
    {
        return _appDb.Courses.ToList();
    }

    public void AssignRoomToCourse(Course course, Room room)
    {

    }
    
}

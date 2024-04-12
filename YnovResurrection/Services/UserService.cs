using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class UserService : AService
{
    private UserService()
    {
        var studentGroups = StudentGroupService.Instance.List();
        var bachelor1 = studentGroups.ElementAt(0);
        var bachelor2 = studentGroups.ElementAt(1);
        var studyingFrench = studentGroups.ElementAt(2);

        CreateUser(firstName: "Ben", studentGroups: [bachelor1, studyingFrench]);
        CreateUser(firstName: "Job", studentGroups: [bachelor1]);
        CreateUser(firstName: "Tom", studentGroups: [bachelor1]);
        CreateUser(firstName: "Ana", studentGroups: [bachelor1]);
        CreateUser(firstName: "Tea", studentGroups: [bachelor1]);
        CreateUser(firstName: "Zoe", studentGroups: [bachelor1]);
        CreateUser(firstName: "Pol", studentGroups: [bachelor1]);
        CreateUser(firstName: "Duh", studentGroups: [bachelor1]);
        CreateUser(firstName: "Albert", studentGroups: [bachelor2, studyingFrench]);
        CreateUser(firstName: "Enrico", studentGroups: [bachelor2]);
        CreateUser(firstName: "Sirena", studentGroups: [bachelor2]);
        CreateUser(firstName: "Duhduh", studentGroups: [bachelor2]);
        CreateUser(firstName: "Director");
        CreateUser(firstName: "ComputerGuy");
        CreateUser(firstName: "TeacherBanjo");
        CreateUser(firstName: "TeacherDJ");
        CreateUser(firstName: "TeacherGuitar");
        CreateUser(firstName: "TeacherFrench");

        bachelor1.Students =
        [
            _fakeData.Single(u => u.FirstName == "Ben"),
            _fakeData.Single(u => u.FirstName == "Job"),
            _fakeData.Single(u => u.FirstName == "Tom"),
            _fakeData.Single(u => u.FirstName == "Ana"),
            _fakeData.Single(u => u.FirstName == "Tea"),
            _fakeData.Single(u => u.FirstName == "Zoe"),
            _fakeData.Single(u => u.FirstName == "Pol"),
            _fakeData.Single(u => u.FirstName == "Duh"),
        ];
        bachelor2.Students =
        [
            _fakeData.Single(u => u.FirstName == "Albert"),
            _fakeData.Single(u => u.FirstName == "Enrico"),
            _fakeData.Single(u => u.FirstName == "Sirena"),
            _fakeData.Single(u => u.FirstName == "Duhduh"),
        ];
        studyingFrench.Students =
        [
            _fakeData.Single(u => u.FirstName == "Ben"),
            _fakeData.Single(u => u.FirstName == "Albert"),
        ];

        var musicHouse = SchoolService.Instance.List().ElementAt(0);
        musicHouse.Admins =
        [
            _fakeData.Single(u => u.FirstName == "Director"),
            _fakeData.Single(u => u.FirstName == "ComputerGuy"),
        ];
        musicHouse.Teachers =
        [
            _fakeData.Single(u => u.FirstName == "TeacherBanjo"),
            _fakeData.Single(u => u.FirstName == "TeacherDJ"),
            _fakeData.Single(u => u.FirstName == "TeacherGuitar"),
            _fakeData.Single(u => u.FirstName == "TeacherFrench"),
        ];
    }

    public static UserService Instance { get; } = new();

    private readonly List<User> _fakeData = [];

    //TODO
    public User CreateUser(string firstName, ICollection<StudentGroup>? studentGroups=null)
    {

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstName,
            LastName = "",
            Email = null,
            Password = null,
            IsSuperAdmin = false,
            StudentGroups = studentGroups ?? []
        };
        _fakeData.Add(user);
        return user;

        // TODO :
        // var user = new User
        // {
        //     FirstName = username,
        //     Email = email,
        //     //Password =
        // };
        //
        // ApplyId(ref user);
        //
        // _appDb.Add(user);
        // Flush();
    }

    public ICollection<User> List()
    {
        return _fakeData; // TODO : _appDb.Users.ToList();
    }

}

using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class UserService : AService
{
    private UserService()
    {
        _fakeData =
        [
            new User { Id = Guid.NewGuid().ToString(), Username = "Ben" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Job" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Tom" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Ana" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Tea" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Zoe" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Pol" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Duh" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Albert" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Enrico" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Sirena" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Duhduh" },
            new User { Id = Guid.NewGuid().ToString(), Username = "Director", IsSuperAdmin = true},
            new User { Id = Guid.NewGuid().ToString(), Username = "ComputerGuy", IsSuperAdmin = true },
            new User { Id = Guid.NewGuid().ToString(), Username = "TeacherBanjo" },
            new User { Id = Guid.NewGuid().ToString(), Username = "TeacherDJ" },
            new User { Id = Guid.NewGuid().ToString(), Username = "TeacherGuitar" },
        ];
    }

    public static UserService Instance { get; } = new();

    private readonly List<User> _fakeData;

    //TODO
    public void CreateUser(string username, string email, string password)
    {
        var user = new User
        {
            Username = username,
            Email = email,
            //Password = 
        };

        ApplyId(ref user);

        _appDb.Add(user);
        Flush();
    }

    public ICollection<User> List()
    {
        return _fakeData; // TODO : _appDb.Users.ToList();
    }

}

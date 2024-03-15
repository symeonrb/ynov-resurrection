using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class UserService : AService
{

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

}
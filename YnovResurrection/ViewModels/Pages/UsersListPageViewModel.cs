using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public class UsersListPageViewModel : IModelListPageViewModel
{
    public Type ModelType => typeof(User);
    public string Title => "Gestion des Utilisateurs";

    public Page? EditModel(ModelListPage page, IModel? modelNullable)
    {
        var userNullable = modelNullable ?? new School();
        if (userNullable is not User user) return null;
        UserPageViewModel editViewModel = new(user)
        {
            Page = page,
            IsEditMode = modelNullable != null,
            IsAddMode = modelNullable == null
        };
        UserPage editPage = new(editViewModel);
        return editPage;
    }

    public void DeleteModel(IModel model)
    {
        if (model is not User user) return;
        UserService.Instance.DeleteUser(user);
    }

    public ICollection<User> List => UserService.Instance.List();
}

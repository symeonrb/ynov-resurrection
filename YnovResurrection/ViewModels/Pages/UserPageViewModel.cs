using YnovResurrection.Models;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public class UserPageViewModel
{
    public required ModelListPage Page { get; set; }
    public User Model { get; private set; }
    public bool IsEditMode { get; set; } = false;
    public bool IsAddMode { get; set; } = false;

    public UserPageViewModel(User user)
    {
        Model = IModel.Clone(user);
    }
}

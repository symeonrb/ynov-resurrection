using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public interface IModelListPageViewModel
{
    public Type ModelType { get; }

    public string Title { get; }

    public Page? EditModel(ModelListPage page, IModel? model);

    public void DeleteModel(IModel model);
}

using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public interface IDataListPageViewModel
{
    public Type ModelType { get; }

    public Page? EditModel(DataListPage page, IModel? model);

    public void DeleteModel(IModel model);
}

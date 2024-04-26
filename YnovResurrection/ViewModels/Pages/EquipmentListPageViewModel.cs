using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public class EquipmentListPageViewModel : IModelListPageViewModel
{
    public Type ModelType => typeof(Equipment);
    public string Title => "Gestion des Équipements";

    public Page? EditModel(ModelListPage page, IModel? modelNullable)
    {
        var equipmentNullable = modelNullable ?? new Course();
        if (equipmentNullable is not Equipment equipment) return null;
        EquipmentPageViewModel editViewModel = new(equipment)
        {
            Page = page,
            IsEditMode = modelNullable != null,
            IsAddMode = modelNullable == null
        };
        EquipmentPage editPage = new(editViewModel);
        return editPage;
    }

    public void DeleteModel(IModel model)
    {
        if (model is not Equipment equipment) return;
        EquipmentService.Instance.DeleteEquipment(equipment);
    }

    public ICollection<Equipment> List => EquipmentService.Instance.List();
}

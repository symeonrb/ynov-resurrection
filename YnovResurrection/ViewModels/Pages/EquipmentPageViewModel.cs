using YnovResurrection.Models;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public class EquipmentPageViewModel
{
    public required ModelListPage Page { get; set; }
    public Equipment Model { get; private set; }
    public bool IsEditMode { get; set; } = false;
    public bool IsAddMode { get; set; } = false;

    public EquipmentPageViewModel(Equipment equipment)
    {
        Model = IModel.Clone(equipment);
    }
}

using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public class RoomPageViewModel
{
    public required ModelListPage Page { get; set; }
    public Room Model { get; private set; }
    public bool IsEditMode { get; set; } = false;
    public bool IsAddMode { get; set; } = false;

    public RoomPageViewModel(Room room)
    {
        Model = IModel.Clone(room);
    }

    public ICollection<Building> Buildings => BuildingService.Instance.List();
}

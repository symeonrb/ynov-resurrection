using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    class RoomsListPageViewModel : IModelListPageViewModel
    {
        public Type ModelType => typeof(Room);
        public string Title => "Gestion des Salles";

        public Page? EditModel(ModelListPage page, IModel? modelNullable)
        {
            var roomNullable = modelNullable ?? new Room();
            if (roomNullable is not Room room) return null;
            RoomPageViewModel editViewModel = new(room)
            {
                Page = page,
                IsEditMode = modelNullable != null,
                IsAddMode = modelNullable == null
            };
            RoomPage editPage = new(editViewModel);
            return editPage;
        }

        public void DeleteModel(IModel model)
        {
            if (model is not Room room) return;
            RoomService.Instance.DeleteRoom(room);
        }

        public ICollection<Room> List => RoomService.Instance.List();
    }
}

using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    class ModulesListPageViewModel : IModelListPageViewModel
    {
        public Type ModelType => typeof(Module);
        public string Title => "Gestion des Modules";

        public Page? EditModel(ModelListPage page, IModel? modelNullable)
        {
            var moduleNullable = modelNullable ?? new Module();
            if (moduleNullable is not Module module) return null;
            ModulePageViewModel editViewModel = new(module)
            {
                Page = page,
                IsEditMode = modelNullable != null,
                IsAddMode = modelNullable == null
            };
            ModulePage editPage = new(editViewModel);
            return editPage;
        }

        public void DeleteModel(IModel model)
        {
            // TODO
            // if (model is not Module module) return;
            // ModuleService.Instance.DeleteModule(module);
        }

        public ICollection<Module> List => ModuleService.Instance.List();
    }
}

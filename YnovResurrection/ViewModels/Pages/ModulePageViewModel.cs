using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public class ModulePageViewModel
{
    public required ModelListPage Page { get; set; }
    public Module Model { get; private set; }
    public bool IsEditMode { get; set; } = false;
    public bool IsAddMode { get; set; } = false;

    public ModulePageViewModel(Module module)
    {
        Model = IModel.Clone(module);
    }

    public ICollection<School> Schools => SchoolService.Instance.List();

    public ICollection<User> Teachers => Model.School.Teachers;

    public IEnumerable<StudentGroup> StudentGroups => StudentGroupService.Instance.FromSchoolId(Model.School.Id);
}

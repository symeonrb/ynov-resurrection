using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public class StudentGroupPageViewModel
{
    public required ModelListPage Page { get; set; }
    public StudentGroup Model { get; private set; }
    public bool IsEditMode { get; set; } = false;
    public bool IsAddMode { get; set; } = false;

    public StudentGroupPageViewModel(StudentGroup studentGroup)
    {
        Model = IModel.Clone(studentGroup);
    }

    public ICollection<School> Schools => SchoolService.Instance.List();
}

using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages;

public class StudentGroupsListPageViewModel : IModelListPageViewModel
{
    public Type ModelType => typeof(StudentGroup);
    public string Title => "Gestion des groupes d'élèves";

    public Page? EditModel(ModelListPage page, IModel? modelNullable)
    {
        var groupNullable = modelNullable ?? new School();
        if (groupNullable is not StudentGroup group) return null;
        StudentGroupPageViewModel editViewModel = new(group)
        {
            Page = page,
            IsEditMode = modelNullable != null,
            IsAddMode = modelNullable == null
        };
        StudentGroupPage editPage = new(editViewModel);
        return editPage;
    }

    public void DeleteModel(IModel model)
    {
        if (model is not StudentGroup group) return;
        StudentGroupService.Instance.DeleteStudentGroup(group);
    }

    public ICollection<StudentGroup> List => StudentGroupService.Instance.List();
}

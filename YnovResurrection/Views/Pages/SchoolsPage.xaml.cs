using System.Windows.Controls;
using YnovResurrection.Services;

namespace YnovResurrection.Views.Pages;

public partial class SchoolsPage : Page
{
    public SchoolsPage()
    {
        InitializeComponent();

        // Définir le DataContext de la page sur lui-même (this)
        listSchools.ItemsSource = SchoolService.Instance.List();
    }
}

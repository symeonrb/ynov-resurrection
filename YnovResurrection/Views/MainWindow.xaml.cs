using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new MainMenu());
        }

        //private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Récupérer l'élément de menu sélectionné
        //    ListBoxItem selectedItem = (sender as ListBox).SelectedItem as ListBoxItem;
        //    if (selectedItem != null)
        //    {
        //        // Naviguer vers la page correspondante
        //        switch (selectedItem.Content.ToString())
        //        {
        //            case "Accueil":
        //                mainFrame.Navigate(new MainMenu());
        //                break;
        //        }
        //    }
        //}

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new MainMenu());
        }
    }
}

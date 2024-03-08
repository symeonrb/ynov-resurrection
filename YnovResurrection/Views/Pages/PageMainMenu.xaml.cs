using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        MainWindow MainWindow { get => (MainWindow) Application.Current.MainWindow; }

        private void Menu1_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new MainMenu());
        }

        private void Menu2_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new MainMenu());
        }

        private void Menu3_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new MainMenu());
        }

        private void Menu4_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new MainMenu());
        }
    }
}

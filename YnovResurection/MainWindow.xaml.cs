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
using YnovResurection.Models;
using YnovResurection.ViewModels;

namespace YnovResurection
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RoomManager roomManager = new RoomManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Course biggest = roomManager.GetCourseWithMostStudents();

            if (biggest != null)
            {
                // Display or use the lesson information
                MessageBox.Show($"Course with most students: Course {biggest.Id} with {biggest.NumStudents} students.");
            }
            else
            {
                MessageBox.Show("No lessons available.");
            }
        }
    }
}

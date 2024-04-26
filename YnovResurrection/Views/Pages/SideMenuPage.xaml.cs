﻿using System.Windows;
using System.Windows.Controls;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour SideMenuPage.xaml
    /// </summary>
    public partial class SideMenuPage : Page
    {
        private static MainWindow MainWindow { get => (MainWindow)Application.Current.MainWindow; }

        public SideMenuPage()
        {
            InitializeComponent();
        }

        private void Buildings_Click(object sender, RoutedEventArgs e)
        {
            ModelListPage page = new(new BuildingsListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            ModelListPage page = new(new CoursesListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }

        private void Modules_Click(object sender, RoutedEventArgs e)
        {
            ModelListPage page = new(new ModulesListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            ModelListPage page = new(new RoomsListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }

        private void Schools_Click(object sender, RoutedEventArgs e)
        {
            ModelListPage page = new(new SchoolsListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }

        private void StudentGroups_Click(object sender, RoutedEventArgs e)
        {
            ModelListPage page = new(new StudentGroupsListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            ModelListPage page = new(new UsersListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }
    }
}

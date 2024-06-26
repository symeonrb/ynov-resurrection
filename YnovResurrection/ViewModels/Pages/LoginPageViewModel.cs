using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;
using YnovResurrection.Views;



namespace YnovResurrection.ViewModels.Pages
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private readonly AuthenticationService _authService = new AuthenticationService();

        private string _username;
        private string _password;
        private string _token;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string Token
        {
            get => _token;
            set { _token = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Login()
        {
            string token = _authService.Login(Username, Password);

            if (token != null)
            {
                MessageBox.Show(token);
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.MainPage.Content = null;
                mainWindow.SideMenuPage.Navigate(new SideMenuPage());


            }
            else
            {

                MessageBox.Show("Identifiant ou mot de passe incorrect.");
            }
        }
    }

}
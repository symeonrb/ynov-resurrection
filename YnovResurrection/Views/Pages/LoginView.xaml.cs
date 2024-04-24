using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{

    public partial class LoginView : Page
    {

        //private readonly AuthenticationService _authService = new AuthenticationService();
        private LoginViewModel _viewModel;

        public LoginView()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            string token = _authService.Login(username, password);

            if (token != null)
            {
                TokenGenerated.Text = "Token Généré : " + token;
            }
            else
            {
                TokenGenerated.Text = "Utilisateur ou MDP incorrect";
            }
        }*/

            _viewModel.Login();

        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
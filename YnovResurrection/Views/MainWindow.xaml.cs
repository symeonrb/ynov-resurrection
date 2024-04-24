using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using static YnovResurrection.Views.MainWindow;
using YnovResurrection.Services;

namespace YnovResurrection.Views
{
    public partial class MainWindow : Window
    {

        private readonly AuthenticationService _authService = new AuthenticationService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateHash_Click(object sender, RoutedEventArgs e)
        {
            string password = passwordBox.Password;
            string hashedPassword = HashPassword(password);
            hashText.Text = "Mot de passe hachée : " + hashedPassword;
        }

        private void GenerateToken_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private string HashPassword(string password)
        {
            // Convertir le mot de passe en tableau de bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Créer un objet de hachage SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Calculer le hachage du mot de passe
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                // Convertir le hachage en une chaîne hexadécimale
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

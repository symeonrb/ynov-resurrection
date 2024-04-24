using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;

namespace YnovResurrection;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application


{
    /*
    private void GenerateHash_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        if (mainWindow != null)
        {
            // Accéder aux éléments de l'interface utilisateur
            PasswordBox passwordBox = mainWindow.passwordBox;
            TextBlock hashText = mainWindow.hashText;

            // Récupérer le mot de passe et générer le hachage
            string password = passwordBox.Password;
            string hashedPassword = HashPassword(password);

            System.Diagnostics.Debug.WriteLine("Mot de passe haché : ");
            MessageBox.Show("Mot de passe haché : " + hashedPassword, "Mot de passe haché");
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
    }*/
}
using System;
using System.Security.Cryptography;
using System.Text;
using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class UserService : AService
{

    //TODO

    public void CreateUser(string username, string email, string password)
    {
        
        // Hash le mdp
        string hashedPassword = HashPassword(password);

        var user = new User
        {
            Username = username,
            Email = email,
            Password = hashedPassword,
        };
        
        ApplyId(ref user);
        
        _appDb.Add(user);
        Flush();
    }

    private string HashPassword(string password)
    {
        // Convertir le mot de passe en tableau de bytes
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        //hachage SHA256
        using (SHA256 sha256 = SHA256.Create())
        {
            // Calculer le hachage du mot de passe
            byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

            //
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

}
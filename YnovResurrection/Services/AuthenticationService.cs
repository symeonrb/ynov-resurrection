using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Windows;
using Microsoft.IdentityModel.Tokens;
using YnovResurrection.Models;

namespace YnovResurrection.Services;


public class AuthenticationService
{
    private readonly string _secretKey = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTcxMTczMDk4NywiaWF0IjoxNzExNzMwOTg3fQ.TI_EgkZksveAfjwLtr5M0vpKdA-3ptMtYzx-W7k56mk";
    private readonly double _tokenExpirationMinutes = 60;

    public string Login(string email, string password)
    {
        bool is_user_logged_in = Authenticate(email, password);

        if (!is_user_logged_in)
        {
            return null; // L'authentification a échoué
        }

        // JWT

        var token = GenerateToken(email);

        return token;
    }

    public bool Authenticate(string email, string password)
    {
        var user = UserService.Instance.List().FirstOrDefault(u => u.Email == email && u.IsSuperAdmin);

        //return email == "admin" && password == "root";

        // Get l'utilisateur correspondant au nom d'utilisateur

        // Vérifier si l'utilisateur existe
        if (user != null)
        {
            // Vérifier si le mot de passe correspond
            if (user.Password == password)
            {
                // Authentification réussie
                MessageBox.Show(user.FirstName + " est connecté");
                return true;
            }
        }

        return false;

    }

    public string GenerateToken(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_tokenExpirationMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken validatedToken);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
}
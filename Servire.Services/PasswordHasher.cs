using Servire.Bll.Interfaces;
using BCrypt.Net;
using System;
using System.Text;

namespace Servire.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            // --- CAMBIO ---
            // Simplemente generamos el hash y lo retornamos.
            // Costo 12, como tenías.
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        public bool Verify(string password, string storedHash)
        {
            // --- CAMBIO ---
            // Ya no decodificamos desde Base64.
            // Comparamos el password contra el hash de la BD directamente.

            if (string.IsNullOrEmpty(storedHash))
            {
                return false;
            }
            try
            {
                // BCrypt.Verify sabe cómo manejar el hash "$2a$12..."
                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            catch (Exception)
            {
                // Si el hash es inválido (ej: texto plano o un hash Base64 antiguo)
                // esto fallará y retornará false.
                return false;
            }
        }
    }
}

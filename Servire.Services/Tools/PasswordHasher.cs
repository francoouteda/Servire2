using Servire.Services.Interfaces;
namespace Servire.Services.Tools
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
           
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        public bool Verify(string password, string storedHash)
        {
            

            if (string.IsNullOrEmpty(storedHash))
            {
                return false;
            }
            try
            {
                
                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            catch (Exception)
            { 
                
               return false;
            }
        }
    }
}

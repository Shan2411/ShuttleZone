    using System;
    using System.Security.Cryptography;
    using System.Text;
    using ShuttleZone.UserManagement;

namespace ShuttleZone.UserManagement
    {
        public static class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();

                    foreach (var b in bytes)
                        builder.Append(b.ToString("x2"));

                    return builder.ToString();
                }
            }

            public static bool VerifyPassword(string inputPassword, string storedHash)
            {
                string hashOfInput = HashPassword(inputPassword);
                return hashOfInput == storedHash;
            }
        }
    }
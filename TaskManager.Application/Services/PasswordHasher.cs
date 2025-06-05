using System.Security.Cryptography;
using System.Text;
using TaskManager.Application.Contracts;

namespace TaskManager.Application.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 100_000;
    

    public string HashPassword(string password)
    {
        using var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA256);
        var key = algorithm.GetBytes(KeySize);
        var salt = algorithm.Salt;

        var hashParts = new StringBuilder();
        hashParts.Append(Convert.ToBase64String(salt));
        hashParts.Append('.');
        hashParts.Append(Convert.ToBase64String(key));
        return hashParts.ToString();
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split('.', 2);
        if (parts.Length != 2)
            return false;

        var salt = Convert.FromBase64String(parts[0]);
        var key = Convert.FromBase64String(parts[1]);

        using var algorithm = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        var keyToCheck = algorithm.GetBytes(KeySize);

        return keyToCheck.SequenceEqual(key);
    }
}
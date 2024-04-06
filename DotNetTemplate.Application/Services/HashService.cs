using System.Security.Cryptography;
using System.Text;
using DotNetTemplate.Application.Interfaces;

public class HashService : IHashService
{
    private readonly int _saltLength;

    public HashService(IConfiguration configuration)
    {
        _saltLength = int.Parse(configuration.GetValue<string>("Cryptography:SaltLength")); // Default to 16 bytes
    }

    public string HashString(string data, string salt)
    {
        using (SHA256 hash = SHA256.Create())
        {
            byte[] hashedBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(salt + data));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public string GenerateSalt()
    {
        byte[] saltBytes = new byte[_saltLength];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    public bool ValidateHash(string data, string hashedData, string salt)
    {
        string newHashedData = this.HashString(data, salt);

        return newHashedData == hashedData;
    }
}

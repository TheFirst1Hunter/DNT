namespace DotNetTemplate.Application.Interfaces;

public interface IHashService : IBaseService
{
    string GenerateSalt();
    string HashString(string data, string salt);
    bool ValidateHash(string data, string hashedData);
}

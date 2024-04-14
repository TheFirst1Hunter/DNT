using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Application.Interfaces;

public interface ITokenService : IBaseService
{
    string GenerateToken(User user);
}
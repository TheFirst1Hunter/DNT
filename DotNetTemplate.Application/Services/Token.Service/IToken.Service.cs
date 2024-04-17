using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Application.Interfaces;

public interface ITokenService : IBaseService
{
    (string accessToken, string refreshToken) GenerateToken(User user);
    Task<(bool isValid, string newAccessToken, string newRefreshToken)> ValidateRefreshTokenAsync(string refreshToken);
}
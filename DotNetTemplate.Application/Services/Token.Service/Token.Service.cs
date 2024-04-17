using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Data.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace DotNetTemplate.Application.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly IUserReadRepository _userReadRepository;
    public TokenService(IConfiguration config, IUserReadRepository userReadRepository)
    {
        _config = config;
        _userReadRepository = userReadRepository;
    }
    public (string accessToken, string refreshToken) GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<String>("JwtAuth:Key")));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

        user.GetPermissions().ForEach(permission =>
        {
            claims.Add(new Claim(permission, "true"));
        });

        var token = new JwtSecurityToken(_config.GetValue<String>("JwtAuth:Issuer"),
          _config.GetValue<String>("JwtAuth:Audience"),
          claims,
          expires: _config.GetValue<int>("JwtAuth:AccessExpiration") > 0 ? DateTime.Now.AddMinutes(_config.GetValue<int>("JwtAuth")) : DateTime.Now.AddMonths(1),
          signingCredentials: credentials);

        var refreshSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<String>("JwtAuth:RefreshKey"))); // Use different key for refresh token

        var refreshCredentials = new SigningCredentials(refreshSecurityKey, SecurityAlgorithms.HmacSha256);

        var refreshClaims = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), new Claim(ClaimTypes.Name, user.Username) };

        var refreshToken = new JwtSecurityToken(_config.GetValue<String>("JwtAuth:Issuer"),
            _config.GetValue<String>("JwtAuth:Audience"),
            refreshClaims,
            expires: _config.GetValue<int>("JwtAuth:RefreshExpiration") > 0 ? DateTime.Now.AddMinutes(_config.GetValue<int>("JwtRefresh")) : DateTime.Now.AddMonths(1),
            signingCredentials: refreshCredentials);

        var accessTokenString = new JwtSecurityTokenHandler().WriteToken(token);
        var refreshTokenString = new JwtSecurityTokenHandler().WriteToken(refreshToken);

        return (accessTokenString, refreshTokenString);
    }
    public async Task<(bool isValid, string newAccessToken, string newRefreshToken)> ValidateRefreshTokenAsync(string refreshToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<String>("JwtAuth:RefreshKey"))), // Use refresh token key
            ValidateIssuer = true,
            ValidIssuer = _config.GetValue<String>("JwtAuth:Issuer"),
            ValidateAudience = true,
            ValidAudience = _config.GetValue<String>("JwtAuth:Audience"),
            ValidateLifetime = true // Ensure token hasn't expired
        };

        try
        {
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out validatedToken);
            var jwtSecurityToken = validatedToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                return (false, null, null);
            }
            Console.WriteLine("-----------------");
            Console.WriteLine(principal.FindFirst(ClaimTypes.Name).Value);
            Console.WriteLine("-----------------");
            User user = await _userReadRepository.GetUserAsync(principal.FindFirst(ClaimTypes.Name).Value);


            var newTokens = GenerateToken(user);

            return (true, newTokens.accessToken, newTokens.refreshToken);
        }
        catch (SecurityTokenException)
        {
            return (false, null, null);
        }
    }


}
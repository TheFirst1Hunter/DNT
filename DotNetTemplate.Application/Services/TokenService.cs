using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace DotNetTemplate.Application.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration config)
    {
        _config = config;
    }
    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<String>("JwtAuth:Key")));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        user.GetPermissions().ForEach(permission =>
        {
            claims.Add(new Claim(permission, "true"));
        });

        var token = new JwtSecurityToken(_config.GetValue<String>("JwtAuth:Issuer"),
          _config.GetValue<String>("JwtAuth:Audience"),
          claims,
          expires: DateTime.Now.AddMonths(1),
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
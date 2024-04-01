using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DotNetTemplate.Application.Extensions;

public static class AuthExtension
{
    public static WebApplicationBuilder AddJWTAuth(
       this WebApplicationBuilder builder)
    {

        String jwtAuthIssuer = builder.Configuration.GetValue<String>("JwtAuth:Issuer");
        String jwtAuthKey = builder.Configuration.GetValue<String>("JwtAuth:Key");
        String jwtAuthAudience = builder.Configuration.GetValue<String>("JwtAuth:Audience");

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtAuthIssuer,
            ValidAudience = jwtAuthAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthKey))
        };
    });

        return builder;
    }
}
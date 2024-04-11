using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DotNetTemplate.Application.Auth.Policies;
using DotNetTemplate.Application.Auth.Roles;

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

        builder.Services.AddAuthorization(options =>
        {
            TodoPolicy todoPolicy = new TodoPolicy();

            options.AddPolicy(nameof(BasePolicy), policy => policy.RequireRole(Roles.Admin));
            options.AddBasePolicies<TodoPolicy>(todoPolicy);
        });

        return builder;
    }
}
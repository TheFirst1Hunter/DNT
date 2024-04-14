using DotNetTemplate.Data.Interfaces;
using DotNetTemplate.Data.Repository;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Application.Services;
using DotNetTemplate.Data;
using DotNetTemplate.Presentation.Extensions;
using DotNetTemplate.Application.Extensions;
using DotNetTemplate.Infrastructure.Middleware;
using DotNetTemplate.Data.Extensions;

namespace DotNetTemplate.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(
       this IServiceCollection service)
    {
        service.AddTransient<IHashService, HashService>();
        service.AddTransient<ITokenService, TokenService>();
        service.AddTransient<IUserService, UserService>();
        return service;
    }
}
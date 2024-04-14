using DotNetTemplate.Data.Interfaces;
using DotNetTemplate.Data.Repository;

namespace DotNetTemplate.Data.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(
       this IServiceCollection service)
    {
        service.AddTransient<ITodoReadRepository, TodoReadRepository>();
        service.AddTransient<ITodoWriteRepository, TodoWriteRepository>();
        service.AddTransient<IUserReadRepository, UserReadRepository>();
        service.AddTransient<IUserWriteRepository, UserWriteRepository>();
        return service;
    }
}
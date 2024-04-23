using DotNetTemplate.Core.Entities;
using DotNetTemplate.Application.Interfaces;
using System.Security.Claims;

namespace DotNetTemplate.Application.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetCurrentUserId()
    {
        Console.WriteLine("token", _httpContextAccessor.HttpContext?.Request.Headers["Authorization"]);
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public string? GetCurrentUserName()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
    }


}

using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Application.Interfaces;

public interface IUserService : IBaseService
{
    string? GetCurrentUserId();
    string? GetCurrentUserName();
}
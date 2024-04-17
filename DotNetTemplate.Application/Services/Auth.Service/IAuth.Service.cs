using DotNetTemplate.Application.DTOs;
using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Application.Interfaces;

public interface IAuthService : IBaseService
{
    bool ValidateUser(User user, string incomingPassword);
    Task<LoginUserResponse> LoginServiceAsync(string incomingUsername, string incomingPassword);
    Task<RegisterUserResponse> RegisterServiceAsync(string username, string password);
}
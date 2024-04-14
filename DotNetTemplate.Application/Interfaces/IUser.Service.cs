using DotNetTemplate.Application.DTOs;
using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Application.Interfaces;

public interface IUserService : IBaseService
{
    bool ValidateUser(User user, string incomingPassword);
    Task<LoginUserResponse> LoginService(string incomingUsername, string incomingPassword);
    Task<RegisterUserResponse> RegisterService(string username, string password);
}
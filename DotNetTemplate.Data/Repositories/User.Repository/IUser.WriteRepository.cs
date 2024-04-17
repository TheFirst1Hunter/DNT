using System;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Data.Interfaces;

public interface IUserWriteRepository
{
    Task<User> RegisterUserAsync(User user);
    Task<User> UpdateUserPermissionsAsync(Guid userId, List<string> permissions);

}
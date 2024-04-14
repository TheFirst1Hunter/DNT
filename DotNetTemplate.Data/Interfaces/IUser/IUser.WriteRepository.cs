using System;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.Filters;

namespace DotNetTemplate.Data.Interfaces;

public interface IUserWriteRepository
{
    Task<User> RegisterUserAsync(User user);
    Task<User> UpdateUserPermissionsAsync(Guid userId, List<string> permissions);

}
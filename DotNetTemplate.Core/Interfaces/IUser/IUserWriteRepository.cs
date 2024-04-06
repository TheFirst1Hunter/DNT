using System;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;

namespace DotNetTemplate.Core.Interfaces;

public interface IUserWriteRepository
{
    Task<User> RegisterUserAsync(User user);
}
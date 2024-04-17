using System;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Data.Interfaces;

public interface IUserReadRepository
{
    Task<User> GetUserAsync(string username);
}
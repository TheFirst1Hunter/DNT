using System;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.Filters;

namespace DotNetTemplate.Data.Interfaces;

public interface IUserReadRepository
{
    Task<User> GetUserAsync(string username);
}
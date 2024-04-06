using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Core.Interfaces;
using DotNetTemplate.Core.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Data.Repository
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private readonly DotNetTemplateDbContext _context;

        public UserWriteRepository(DotNetTemplateDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            User u = (await _context.Users.AddAsync(user)).Entity;

            await _context.SaveChangesAsync();

            return u;
        }
    }
}

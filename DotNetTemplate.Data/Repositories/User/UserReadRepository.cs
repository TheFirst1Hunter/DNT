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
    public class UserReadRepository : IUserReadRepository

    {
        private readonly DotNetTemplateDbContext _context;

        public UserReadRepository(DotNetTemplateDbContext context)
        {
            _context = context;
        }


        public async Task<User> GetUserAsync(string username)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.GetUsername() == username);

            if (user == null)
            {
                throw new InvalidCredentialsExceptions();
            }

            return user;
        }
    }
}

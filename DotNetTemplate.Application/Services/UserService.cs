using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetTemplate.Application.Interfaces;
// using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Application.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using DotNetTemplate.Core.Exceptions;
using DotNetTemplate.Application.Auth.Roles;

namespace DotNetTemplate.Application.Services;

public class UserService : IUserService
{
    private readonly IUserReadRepository _readRepository;
    private readonly IUserWriteRepository _writeRepository;
    private readonly IHashService _hashService;
    private readonly ITokenService _tokenService;

    public UserService(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IHashService hashService, ITokenService tokenService)
    {
        _readRepository = userReadRepository;
        _writeRepository = userWriteRepository;
        _hashService = hashService;
        _tokenService = tokenService;
    }

    public bool ValidateUser(User user, string incomingPassword)
    {
        return _hashService.ValidateHash(incomingPassword, user.Password, user.Salt);
    }

    public async Task<LoginUserResponse> LoginService(string incomingUsername, string incomingPassword)
    {
        User u = await _readRepository.GetUserAsync(incomingUsername);

        bool isValid = this.ValidateUser(u, incomingPassword);

        if (!isValid)
        {
            throw new InvalidCredentialsExceptions();
        }

        string token = _tokenService.GenerateToken(u);

        return new LoginUserResponse(u.GetUsername(), "", token, token, u.GetRole());
    }

    public async Task<RegisterUserResponse> RegisterService(string username, string password)
    {
        string salt = _hashService.GenerateSalt();

        string hashedPassword = _hashService.HashString(password, salt);

        User newUser = new User(username, hashedPassword, salt, Roles.User);

        User userEntity = await _writeRepository.RegisterUserAsync(newUser);

        string token = _tokenService.GenerateToken(userEntity);

        RegisterUserResponse registerUserResponse = new RegisterUserResponse(userEntity.GetUsername(), "", token, token, Roles.User);

        return registerUserResponse;
    }
}
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

namespace DotNetTemplate.Application.Services;

public class UserService : IUserService
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IHashService _hashService;
    private readonly ITokenService _tokenService;

    public UserService(IUserReadRepository userReadRepository, IHashService hashService, ITokenService tokenService)
    {
        _userReadRepository = userReadRepository;
        _hashService = hashService;
        _tokenService = tokenService;
    }

    public bool ValidateUser(User user, string incomingPassword)
    {
        return _hashService.ValidateHash(incomingPassword, user.GetPassword());
    }

    public async Task<LoginUserResponse> LoginService(string incomingUsername, string incomingPassword)
    {
        User u = await _userReadRepository.GetUserAsync(incomingUsername);

        Boolean isValid = this.ValidateUser(u, incomingPassword);

        if (!isValid)
        {
            throw new Exception();
        }

        string token = _tokenService.GenerateToken(u);

        return new LoginUserResponse(u.GetUsername(), "", token, token);
    }
}
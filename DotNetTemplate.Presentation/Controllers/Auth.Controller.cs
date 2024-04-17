using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using DotNetTemplate.Application.Auth.Roles;
using DotNetTemplate.Core.Exceptions;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserWriteRepository _writeRepository;
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public AuthController(IUserWriteRepository writeRepository,
                          IAuthService userService,
                          ITokenService tokenService)
    {
        _writeRepository = writeRepository;
        _authService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("/Register")]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserDto RegisterUserDto)
    {
        RegisterUserResponse registerUserResponse = await _authService.RegisterServiceAsync(RegisterUserDto.Username, RegisterUserDto.Password);

        return (registerUserResponse);
    }

    [HttpPost("/Login")]
    public async Task<ActionResult<LoginUserResponse>> LoginUser([FromBody] LoginUserDto LoginUserDto)
    {
        LoginUserResponse userResponse = await _authService.LoginServiceAsync(LoginUserDto.Username, LoginUserDto.Password);

        return (userResponse);
    }

    [HttpPost("/RefreshToken")]
    [Authorize]
    public async Task<ActionResult<LoginUserResponse>> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        var (isValid, newAccessToken, newRefreshToken) = await _tokenService.ValidateRefreshTokenAsync(refreshTokenDto.RefreshToken);

        if (!isValid)
        {
            throw new InvalidRefreshTokenExceptions();
        }

        return new LoginUserResponse("", "", newAccessToken, newRefreshToken, "");
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPut("/{id}/Permissions")]
    public async Task<ActionResult> UpdateUserPermissions([FromRoute] Guid id, [FromBody] UpdateUserPermissionDto updateUserPermissionsRequest)
    {
        await _writeRepository.UpdateUserPermissionsAsync(id, updateUserPermissionsRequest.Permissions);

        return Ok();
    }
}

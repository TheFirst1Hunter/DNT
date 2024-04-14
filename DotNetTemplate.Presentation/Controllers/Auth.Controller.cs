using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using DotNetTemplate.Application.Auth.Roles;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserWriteRepository _writeRepository;
    private readonly IUserService _userService;


    public AuthController(IUserWriteRepository writeRepository,
                          IUserService userService)
    {
        _writeRepository = writeRepository;
        _userService = userService;
    }

    [HttpPost("/Register")]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserDto RegisterUserDto)
    {
        RegisterUserResponse registerUserResponse = await _userService.RegisterService(RegisterUserDto.Username, RegisterUserDto.Password);

        return (registerUserResponse);
    }

    [HttpPost("/Login")]
    public async Task<ActionResult<LoginUserResponse>> LoginUser([FromBody] LoginUserDto LoginUserDto)
    {
        LoginUserResponse userResponse = await _userService.LoginService(LoginUserDto.Username, LoginUserDto.Password);

        return (userResponse);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPut("/{id}/Permissions")]
    public async Task<ActionResult> UpdateUserPermissions([FromRoute] Guid id, [FromBody] UpdateUserPermissionDto updateUserPermissionsRequest)
    {
        await _writeRepository.UpdateUserPermissionsAsync(id, updateUserPermissionsRequest.Permissions);

        return Ok();
    }
}

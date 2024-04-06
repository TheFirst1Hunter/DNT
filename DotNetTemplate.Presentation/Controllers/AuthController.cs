using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Application.DTOs;

public class AuthController : ControllerBase

{
    private readonly IUserReadRepository _readRepository;
    private readonly IUserWriteRepository _writeRepository;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly IHashService _hashService;
    private readonly IMapper _mapper;

    public AuthController(IUserWriteRepository writeRepository,
                          IUserReadRepository readRepository,
                          ITokenService tokenService,
                          IHashService hashService,
                          IUserService userService,
                          IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
        _tokenService = tokenService;
        _hashService = hashService;
        _userService = userService;
    }

    [HttpPost("/Register")]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
    {
        RegisterUserResponse registerUserResponse = await _userService.RegisterService(registerUserRequest.Username, registerUserRequest.Password);

        return Ok(registerUserResponse);
    }

    [HttpPost("/Login")]
    public async Task<ActionResult<LoginUserResponse>> LoginUser([FromBody] LoginUserRequest loginUserRequest)
    {
        LoginUserResponse userResponse = await _userService.LoginService(loginUserRequest.Username, loginUserRequest.Password);

        return Ok(userResponse);
    }

}
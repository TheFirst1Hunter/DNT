using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Presentation.DTOs;

public class LoginUserResponse : User
{
    public string accessToken { set; get; }
    public string refreshToken { set; get; }
}
using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Application.DTOs;

public class LoginUserResponse : User
{
    public string AccessToken { set; get; }
    public string RefreshToken { set; get; }

    public LoginUserResponse(string username, string password, string accessToken, string refreshToken) : base(username, password, "")
    {
        this.AccessToken = accessToken;
        this.RefreshToken = refreshToken;
    }
}
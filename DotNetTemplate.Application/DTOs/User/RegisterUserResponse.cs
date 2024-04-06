using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Application.DTOs;

public class RegisterUserResponse : User
{
    public string AccessToken { set; get; }
    public string RefreshToken { set; get; }

    public RegisterUserResponse(string username, string password, string accessToken, string refreshToken) : base(username, password)
    {
        this.AccessToken = accessToken;
        this.RefreshToken = refreshToken;
    }
}
using System;
namespace DotNetTemplate.Core.Entities;

public class User : BaseEntity<Guid>
{
    private string Username { set; get; }
    private string Password { set; get; }

    public string GetPassword() => this.Password;

    public void SetPassword(string newPassword)
    {
        this.Password = newPassword;
    }
    public string GetUsername() => this.Username;

    public User(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }
}
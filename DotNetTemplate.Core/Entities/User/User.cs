using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotNetTemplate.Core.Entities;


public class User : BaseEntity<Guid>
{
    public string Username { set; get; }
    public string Password { set; get; }
    public string Salt { set; get; }

    public string GetPassword() => this.Password;

    public void SetPassword(string newPassword)
    {
        this.Password = newPassword;
    }
    public string GetUsername() => this.Username;

    public User() { }

    public User(string username, string password, string salt)
    {
        this.Username = username;
        this.Password = password;
        this.Salt = salt;
    }
}
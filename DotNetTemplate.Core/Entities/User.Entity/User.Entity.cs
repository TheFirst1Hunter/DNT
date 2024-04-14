using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotNetTemplate.Core.Entities;


public class User : BaseEntity<Guid>
{
    public string Username { set; get; }
    public string Password { set; get; }
    public string Salt { set; get; }
    public string Role { set; get; }
    public List<string> Permissions { set; get; } = new List<string>();
    public string GetPassword() => this.Password;

    public void SetPassword(string newPassword)
    {
        this.Password = newPassword;
    }

    public string GetUsername() => this.Username;
    public void SetPermissions(List<string> permissions)
    {
        this.Permissions = permissions;
    }

    public void AddPermission(string permission)
    {
        this.Permissions.Add(permission);
    }

    public void RemovePermission(string permission)
    {
        this.Permissions.Remove(permission);
    }

    public List<string> GetPermissions() => this.Permissions;

    public void SetRole(string role)
    {
        this.Role = role;
    }

    public string GetRole() => this.Role;

    public User() { }

    public User(string username, string password, string salt, string role)
    {
        this.Username = username;
        this.Password = password;
        this.Salt = salt;
        this.Role = role;
    }
}
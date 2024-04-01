using System;
namespace DotNetTemplate.Core.Entities;

public class User : BaseEntity<Guid>
{
    public string Username { set; get; }
    public string Password { set; get; }
}
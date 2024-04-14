using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Presentation.DTOs;

public class LoginUserDto
{
    [Required]
    public string Username { set; get; }

    [Required]
    public string Password { set; get; }
}
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Presentation.DTOs;


public class RegisterUserDto
{
    [Required]
    public string Username { set; get; }
    [Required]
    public string Password { set; get; }
}
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Presentation.DTOs;


public class RefreshTokenDto
{

    [Required]
    public string RefreshToken { set; get; }
}

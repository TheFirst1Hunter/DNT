using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Presentation.DTOs;

public class UpdateUserPermissionDto
{
    [Required]
    // [RegularExpression("^(List|Read|Create|Delete|Fetch|Mutate|All):.*$", ErrorMessage = "Invalid permission format")]
    public List<string> Permissions { set; get; }
}
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Models;

public class Role 
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Role Name is required")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enter in proper format")]
    public string Name { get; set; } = string.Empty;

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enter in proper format")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role Location is required")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enter in proper format")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role Department is required")]
    public required Department Department { get; set; }
}
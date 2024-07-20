using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Models;
public class Employee 
{
    [Required(ErrorMessage = "EmpNo is required")]
    [RegularExpression(@"^TZ\d{4}$", ErrorMessage = "Enter in TZXXXX format")]
    public string EmpNo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Profile Picture is required")]
    public string ProfilePicture { get; set; } = string.Empty;

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email ID is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string EmailId { get; set; } = string.Empty;

    [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile No. must be a 10-digit number")]
    public string MobileNo { get; set; } = string.Empty;

    [RegularExpression(@"^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$", ErrorMessage = "Enter proper format")]
    public string DateOfBirth { get; set; } = string.Empty;

    [Required(ErrorMessage = "Join Date is required")]
    [RegularExpression(@"^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$", ErrorMessage = "Enter proper format")]
    public string JoinDate { get; set; } = string.Empty;

    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required")]
    public required Department Department { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public required Role Role { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public string Status { get; set; } = string.Empty;

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enter Alphabets Only")]
    public string Manager { get; set; } = string.Empty;

    [Required(ErrorMessage = "Project is required")]
    public required Project Project { get; set; }
}
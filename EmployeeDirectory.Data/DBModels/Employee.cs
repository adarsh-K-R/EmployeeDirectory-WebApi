using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDirectory.Data.DBModels
{
    public class Employee
    {
        [Key]
        public required string EmpNo { get; set; }

        [Required]
        public required string ProfilePicture { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string EmailId { get; set; }

        public string? MobileNo { get; set; }

        public string? DateOfBirth { get; set; }

        [Required]
        public required string JoinDate { get; set; }

        [Required]
        public required string Location { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [Required]
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        [Required]
        public required string Status { get; set; }

        public string? Manager { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }
    }
}

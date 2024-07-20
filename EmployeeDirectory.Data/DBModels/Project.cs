using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Data.DBModels
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = [];
    }
}

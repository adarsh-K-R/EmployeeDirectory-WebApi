using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDirectory.Data.DBModels
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        
        public virtual ICollection<Role> Roles { get; set; } = [];
        public virtual ICollection<Employee> Employees { get; set; } = [];
    }
}

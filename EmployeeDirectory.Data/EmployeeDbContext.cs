using EmployeeDirectory.Data.DBModels;
using User = EmployeeDirectory.Models.AppUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EmployeeDirectory.Data
{
    public class EmployeeDbContext : IdentityDbContext<User>
    {
        public EmployeeDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Department
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Role
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Project
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Project)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // Role Department
            modelBuilder.Entity<Role>()
                .HasOne(r => r.Department)
                .WithMany(d => d.Roles)
                .HasForeignKey(r => r.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "PE" },
                new Department { Id = 2, Name = "IT" },
                new Department { Id = 3, Name = "HR" },
                new Department { Id = 4, Name = "QA" }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "WebApp" },
                new Project { Id = 2, Name = "Website" },
                new Project { Id = 3, Name = "iOS App" }
            );

            List<IdentityRole> iRoles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(iRoles);
        }
    }
}

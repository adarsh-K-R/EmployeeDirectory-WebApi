using EmployeeDirectory.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Data.Repositories;
public class RoleRepository : IRoleRepository
{
    private readonly EmployeeDbContext _employeeDbContext;

    public RoleRepository(EmployeeDbContext employeeDbContext)
    {
        _employeeDbContext = employeeDbContext;
    }
    public List<Models.Role> GetAll()
    {
        var roles = _employeeDbContext.Roles
            .Include(r => r.Department)
            .Select(r => new Models.Role
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description!,
                Location = r.Location,
                Department = new Models.Department
                {
                    Id = r.Department.Id,
                    Name = r.Department.Name
                }
            })
            .ToList();

        return roles;
    }

    public List<Models.Role> GetByDepartmentId(string Id)
    {
        var departmentRoles = _employeeDbContext.Roles
            .Include(r => r.Department)
            .Where(r => r.DepartmentId == Convert.ToInt32(Id))
            .Select(r => new Models.Role
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description!,
                Location = r.Location,
                Department = new Models.Department
                {
                    Id = r.Department.Id,
                    Name = r.Department.Name
                }
            })
            .ToList();

        return departmentRoles;

    }

    public Models.Role GetByRoleId(string Id)
    {
        var role = _employeeDbContext.Roles
            .Include(r => r.Department)
            .Where(r => r.Id == Convert.ToInt32(Id))
            .Select(r => new Models.Role
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description!,
                Location = r.Location,
                Department = new Models.Department
                {
                    Id = r.Department.Id,
                    Name = r.Department.Name
                }
            })
            .FirstOrDefault();

        return role!;
    }

    public DBModels.Role Add(DBModels.Role role)
    {
        var newRole = new DBModels.Role {
            Name = role.Name,
            DepartmentId = role.DepartmentId,
            Description = role.Description,
            Location = role.Location
        };
        _employeeDbContext.Roles.Add(newRole);

        return newRole;
    }
}
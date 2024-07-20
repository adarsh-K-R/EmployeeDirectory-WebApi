using EmployeeDirectory.Data.Contracts;

namespace EmployeeDirectory.Data.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly EmployeeDbContext _employeeDbContext;

    public DepartmentRepository(EmployeeDbContext employeeDbContext)
    {
        _employeeDbContext = employeeDbContext;
    }
    public List<Models.Department> GetAll()
    {
        List<Models.Department> departments = _employeeDbContext.Departments
                .Select(e => new Models.Department
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToList();

        return departments;
    }
}
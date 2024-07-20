using EmployeeDirectory.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly EmployeeDbContext _employeeDbContext;

    public EmployeeRepository(EmployeeDbContext employeeDbContext) 
    {
        _employeeDbContext = employeeDbContext;
    }

    public List<Models.Employee> GetAll()
    {
        var employees = _employeeDbContext.Employees
            .Include(e => e.Department)
            .Include(e => e.Role)
            .ThenInclude(r => r.Department)
            .Include(e => e.Project)
            .Select(e => new Models.Employee
            {
                EmpNo = e.EmpNo,
                ProfilePicture = e.ProfilePicture,
                FirstName = e.FirstName,
                LastName = e.LastName,
                EmailId = e.EmailId,
                MobileNo = e.MobileNo!,
                DateOfBirth = e.DateOfBirth!,
                JoinDate = e.JoinDate,
                Location = e.Location,
                Department = new Models.Department
                {
                    Id = e.Department.Id,
                    Name = e.Department.Name
                },
                Role = new Models.Role
                {
                    Id = e.Role.Id,
                    Name = e.Role.Name,
                    Description = e.Role.Description!,
                    Location = e.Role.Location,
                    Department = new Models.Department
                    {
                        Id = e.Role.Department.Id,
                        Name = e.Role.Department.Name
                    }
                },
                Status = e.Status,
                Manager = e.Manager!,
                Project = new Models.Project
                {
                    Id = e.Project.Id,
                    Name = e.Project.Name
                }
            })
            .ToList();

        return employees;
    }

    public Models.Employee? GetByEmpNo(string empNo)
    {    
        var employee = _employeeDbContext.Employees
            .Include(e => e.Department)
            .Include(e => e.Role)
            .ThenInclude(r => r.Department)
            .Include(e => e.Project)
            .Where(e => e.EmpNo == empNo)
            .Select(e => new Models.Employee
            {
                EmpNo = e.EmpNo,
                ProfilePicture = e.ProfilePicture,
                FirstName = e.FirstName,
                LastName = e.LastName,
                EmailId = e.EmailId,
                MobileNo = e.MobileNo!,
                DateOfBirth = e.DateOfBirth!,
                JoinDate = e.JoinDate,
                Location = e.Location,
                Department = new Models.Department
                {
                    Id = e.Department.Id,
                    Name = e.Department.Name
                },
                Role = new Models.Role
                {
                    Id = e.Role.Id,
                    Name = e.Role.Name,
                    Description = e.Role.Description!,
                    Location = e.Role.Location,
                    Department = new Models.Department
                    {
                        Id = e.Role.Department.Id,
                        Name = e.Role.Department.Name
                    }
                },
                Status = e.Status,
                Manager = e.Manager!,
                Project = new Models.Project
                {
                    Id = e.Project.Id,
                    Name = e.Project.Name
                }
            })
            .FirstOrDefault();

        return employee;
    }

    public DBModels.Employee Add(DBModels.Employee employee)
    {
        _employeeDbContext.Employees.Add(new DBModels.Employee {
            EmpNo = employee.EmpNo,
            ProfilePicture = employee.ProfilePicture,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            EmailId = employee.EmailId,
            MobileNo = employee.MobileNo,
            DateOfBirth = employee.DateOfBirth,
            JoinDate = employee.JoinDate,
            Location = employee.Location,
            DepartmentId = employee.DepartmentId,
            RoleId = employee.RoleId,
            Status = employee.Status,
            Manager = employee.Manager,
            ProjectId = employee.ProjectId
        });
        

        return employee;
    }

    public bool Update(DBModels.Employee employee)
    {
        var existingEmployee = _employeeDbContext.Employees.Find(employee.EmpNo);

        if (existingEmployee == null)
            return false;

        existingEmployee.ProfilePicture = employee.ProfilePicture;
        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.EmailId = employee.EmailId;
        existingEmployee.MobileNo = employee.MobileNo;
        existingEmployee.DateOfBirth = employee.DateOfBirth;
        existingEmployee.JoinDate = employee.JoinDate;
        existingEmployee.Location = employee.Location;
        existingEmployee.DepartmentId = employee.DepartmentId;
        existingEmployee.RoleId = employee.RoleId;
        existingEmployee.Status = employee.Status;
        existingEmployee.Manager = employee.Manager;
        existingEmployee.ProjectId = employee.ProjectId;

        return true;
    }

    public bool Delete(string empNo)
    {
        var employee = _employeeDbContext.Employees.FirstOrDefault(e => e.EmpNo == empNo);

        if (employee == null)
            return false;

        _employeeDbContext.Employees.Remove(employee);

        return true;
    }
}
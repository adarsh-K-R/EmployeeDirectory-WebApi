using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contracts;

public interface IProjectService
{
    public List<Project> GetAll();
}
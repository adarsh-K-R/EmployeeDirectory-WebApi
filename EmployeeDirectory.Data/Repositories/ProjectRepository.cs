using EmployeeDirectory.Data.Contracts;

namespace EmployeeDirectory.Data.Repositories;
public class ProjectRepository : IProjectRepository
{   
    private readonly EmployeeDbContext _employeeDbContext;
    public ProjectRepository(EmployeeDbContext employeeDbContext) 
    {
        _employeeDbContext = employeeDbContext;
    }
    public List<Models.Project> GetAll()
    {
        List<Models.Project> projects = [.. _employeeDbContext.Projects
                .Select(e => new Models.Project
                {
                    Id = e.Id,
                    Name = e.Name
                })];
                
        return projects;
    }
}
using EmployeeDirectory.Data.Contracts;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contracts;

namespace EmployeeDirectory.Services.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository) 
    {
        _projectRepository = projectRepository;
    }
    public List<Project> GetAll() 
    {
        return _projectRepository.GetAll();
    }
}
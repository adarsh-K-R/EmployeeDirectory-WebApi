using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Api.Controllers;

[Route("api/project")]
[ApiController]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var projects = _projectService.GetAll();
        return Ok(projects);
    }
}
using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Api.Controllers;

[Route("api/department")]
[ApiController]
[Authorize]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;
    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var departments = _departmentService.GetAll();
        return Ok(departments);
    }
}
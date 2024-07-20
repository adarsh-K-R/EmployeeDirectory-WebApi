using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeDirectory.Api.Controllers;

[Route("api/role")]
[ApiController]
[Authorize]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var roles = _roleService.GetAll();
        return Ok(roles);
    }

    [HttpGet("dept/{id}")]
    public IActionResult GetByDepartmentId([FromRoute] string id)
    {
        var roles = _roleService.GetByDepartmentId(id);

        if(roles == null) 
        {
            return NotFound();
        }
        
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public IActionResult GetByRoleId([FromRoute] string id)
    {
        var role = _roleService.GetByRoleId(id);

        if(role == null) 
        {
            return NotFound();
        }
        
        return Ok(role);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Role role)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        var res = _roleService.Add(role);
        return CreatedAtAction(nameof(GetByRoleId), new { id = res.Id }, res);
    }
}
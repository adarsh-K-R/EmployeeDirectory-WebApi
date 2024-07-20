using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeDirectory.Api.Controllers;

[Route("api/employee")]
[ApiController]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _employeeService.GetAll();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] string id)
    {
        var employee = _employeeService.GetByEmpNo(id);

        if(employee == null) 
        {
            return NotFound();
        }
        
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Employee employee)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        
        return CreatedAtAction(nameof(GetById), new { id = employee.EmpNo }, _employeeService.Add(employee));
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] string id, [FromBody] Employee employee)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        bool res = _employeeService.Update(employee);
        
        if(res)
        {
            return Ok(employee);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        bool res = _employeeService.Delete(id);

        if(res)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
using Application.Features.Employees.Commands;
using Application.Features.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmployeeController(IMediator mediator) : AbstractController(mediator)
{
    [HttpPost("")]
    public async Task<IActionResult> Create(AddEmployee request)
    {
        var response = await Mediator.Send(request);
        return StatusCode(response.StatusCode, response.Data);
    }
    
    [HttpPut("")]
    public async Task<IActionResult> Update(UpdateEmployee request)
    {
        var response = await Mediator.Send(request);
        return StatusCode(response.StatusCode, response.Data);
    }
    
    [HttpDelete("")]
    public async Task<IActionResult> Delete([FromQuery] RemoveEmployee request)
    {
        var response = await Mediator.Send(request);
        return StatusCode(response.StatusCode, response.Data);
    }
    
    [HttpGet("List")]
    public async Task<IActionResult> List([FromQuery] ListEmployees request)
    {
        var response = await Mediator.Send(request);
        return StatusCode(response.StatusCode, response.Data);
    }
}
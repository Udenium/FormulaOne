using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        : base(unitOfWork, mapper, mediator)
    {
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var query = new GetAllDriversQuery();

        var result = await _mediator.Send(query);
        
        return Ok(result);
    }

    [HttpGet("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var query = new GetDriverQuery(driverId);

        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driverRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var command = new CreateDriverInfoRequest(driverRequest);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driverRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var command = new UpdateDriverInfoRequest(driverRequest);
        var result = await _mediator.Send(command);

        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var command = new DeleteDriverInfoRequest(driverId);
        var result = await _mediator.Send(command);

        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }
}
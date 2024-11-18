using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.Control.Domain.Services;
using SmartFlow_Platform.Control.Domain.Model.Commands;
using SmartFlow_Platform.Control.Domain.Model.Queries;
using SmartFlow_Platform.Control.Interfaces.REST.Resources;
using SmartFlow_Platform.Control.Interfaces.REST.Transform;

namespace SmartFlow_Platform.Control.Interfaces.REST;

[ApiController]
[Route("api/controles")]
public class ControlController : ControllerBase
{
    private readonly IControlCommandService _commandService;
    private readonly IControlQueryService _queryService;

    public ControlController(IControlCommandService commandService, IControlQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var controles = await _queryService.Handle(new GetAllControlesQuery());
        var resources = controles.Select(ControlResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var control = await _queryService.Handle(new GetControlByIdQuery(id));
        if (control == null) return NotFound();

        var resource = ControlResourceFromEntityAssembler.ToResourceFromEntity(control);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateControlResource resource)
    {
        var command = CreateControlCommandFromResourceAssembler.ToCommandFromResource(resource);
        var control = await _commandService.Handle(command);

        var createdResource = ControlResourceFromEntityAssembler.ToResourceFromEntity(control!);
        return CreatedAtAction(nameof(GetById), new { id = control!.Id }, createdResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateControlResource resource)
    {
        if (id != resource.Id) return BadRequest();

        var command = UpdateControlCommandFromResourceAssembler.ToCommandFromResource(resource);
        var updated = await _commandService.Handle(command);
        if (updated == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _commandService.Handle(new DeleteControlCommand(id));
        return result ? NoContent() : NotFound();
    }
}

using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.Alarmas.Application.Internal.CommandServices;
using SmartFlow_Platform.Alarmas.Application.Internal.QueryServices;
using SmartFlow_Platform.Alarmas.Domain.Model.Commands;
using SmartFlow_Platform.Alarmas.Domain.Model.Queries;
using SmartFlow_Platform.Alarmas.Domain.Services;
using SmartFlow_Platform.Alarmas.Interfaces.REST.Resources;
using SmartFlow_Platform.Alarmas.Interfaces.REST.Transform;

namespace SmartFlow_Platform.Alarmas.Interfaces.REST;

[ApiController]
[Route("api/alarmas")]
public class AlarmasController : ControllerBase
{
    private readonly IAlarmasCommandService _commandService;
    private readonly IAlarmasQueryService _queryService;

    public AlarmasController(IAlarmasCommandService commandService, IAlarmasQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alarmas = await _queryService.Handle(new GetAllAlarmasQuery());
        var resources = alarmas.Select(AlarmaResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var alarma = await _queryService.Handle(new GetAlarmaByIdQuery(id));
        if (alarma == null) return NotFound();

        var resource = AlarmaResourceFromEntityAssembler.ToResourceFromEntity(alarma);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAlarmaResource resource)
    {
        var command = CreateAlarmaCommandFromResourceAssembler.ToCommandFromResource(resource);
        var alarma = await _commandService.Handle(command);

        var createdResource = AlarmaResourceFromEntityAssembler.ToResourceFromEntity(alarma!);
        return CreatedAtAction(nameof(GetById), new { id = alarma!.Id }, createdResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAlarmaResource resource)
    {
        if (id != resource.Id) return BadRequest();

        var command = UpdateAlarmaCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var updated = await _commandService.Handle(command);
        if (updated == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _commandService.Handle(new DeleteAlarmaCommand(id));
        return result ? NoContent() : NotFound();
    }
}

using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.Registros.Domain.Model.Commands;
using SmartFlow_Platform.Registros.Domain.Model.Queries;
using SmartFlow_Platform.Registros.Domain.Services;
using SmartFlow_Platform.Registros.Interfaces.REST.Resources;
using SmartFlow_Platform.Registros.Interfaces.REST.Transform;

namespace SmartFlow_Platform.Registros.Interfaces.REST;

[ApiController]
[Route("api/registros")]
public class RegistroController : ControllerBase
{
    private readonly IRegistroCommandService _commandService;
    private readonly IRegistroQueryService _queryService;

    public RegistroController(IRegistroCommandService commandService, IRegistroQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var registros = await _queryService.Handle(new GetAllRegistrosQuery());
        var resources = registros.Select(RegistroResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var registro = await _queryService.Handle(new GetRegistroByIdQuery(id));
        if (registro == null) return NotFound();

        var resource = RegistroResourceFromEntityAssembler.ToResourceFromEntity(registro);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRegistroResource resource)
    {
        var command = CreateRegistroCommandFromResourceAssembler.ToCommandFromResource(resource);
        var registro = await _commandService.Handle(command);

        var createdResource = RegistroResourceFromEntityAssembler.ToResourceFromEntity(registro!);
        return CreatedAtAction(nameof(GetById), new { id = registro!.Id }, createdResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRegistroResource resource)
    {
        if (id != resource.Id) return BadRequest();

        var command = UpdateRegistroCommandFromResourceAssembler.ToCommandFromResource(resource);
        var updated = await _commandService.Handle(command);
        if (updated == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _commandService.Handle(new DeleteRegistroCommand(id));
        return result ? NoContent() : NotFound();
    }
}

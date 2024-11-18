using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.Consumos.Domain.Model.Commands;
using SmartFlow_Platform.Consumos.Domain.Model.Queries;
using SmartFlow_Platform.Consumos.Domain.Services;
using SmartFlow_Platform.Consumos.Interfaces.REST.Resources;
using SmartFlow_Platform.Consumos.Interfaces.REST.Transform;

namespace SmartFlow_Platform.Consumos.Interfaces.REST;

[ApiController]
[Route("api/consumos")]
public class ConsumoController : ControllerBase
{
    private readonly IConsumoCommandService _commandService;
    private readonly IConsumoQueryService _queryService;

    public ConsumoController(IConsumoCommandService commandService, IConsumoQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var consumos = await _queryService.Handle(new GetAllConsumosQuery());
        var resources = consumos.Select(ConsumoResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var consumo = await _queryService.Handle(new GetConsumoByIdQuery(id));
        if (consumo == null) return NotFound();

        var resource = ConsumoResourceFromEntityAssembler.ToResourceFromEntity(consumo);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateConsumoResource resource)
    {
        var command = CreateConsumoCommandFromResourceAssembler.ToCommandFromResource(resource);
        var consumo = await _commandService.Handle(command);

        var createdResource = ConsumoResourceFromEntityAssembler.ToResourceFromEntity(consumo!);
        return CreatedAtAction(nameof(GetById), new { id = consumo!.Id }, createdResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateConsumoResource resource)
    {
        if (id != resource.Id) return BadRequest();

        var command = UpdateConsumoCommandFromResourceAssembler.ToCommandFromResource(resource);
        var updated = await _commandService.Handle(command);
        if (updated == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _commandService.Handle(new DeleteConsumoCommand(id));
        return result ? NoContent() : NotFound();
    }
}

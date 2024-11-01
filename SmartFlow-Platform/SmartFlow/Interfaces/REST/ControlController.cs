using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.SmartFlow.Application.Internal.CommandServices;
using SmartFlow_Platform.SmartFlow.Application.Internal.QueryServices;
using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

namespace SmartFlow_Platform.SmartFlow.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
public class ControlController : ControllerBase
{
    private readonly ControlCommandService _controlCommandService;
    private readonly ControlQueryService _controlQueryService;

    public ControlController(ControlCommandService controlCommandService, ControlQueryService controlQueryService)
    {
        _controlCommandService = controlCommandService;
        _controlQueryService = controlQueryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _controlQueryService.GetAllControlAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _controlQueryService.GetControlByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(Control control)
    {
        await _controlCommandService.AddControlAsync(control);
        return CreatedAtAction(nameof(Get), new { id = control.Id }, control);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Control control)
    {
        control.Id = id;
        await _controlCommandService.UpdateControlAsync(control);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _controlCommandService.DeleteControlAsync(id);
        return NoContent();
    }
}
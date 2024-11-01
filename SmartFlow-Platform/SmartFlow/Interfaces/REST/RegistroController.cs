using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.SmartFlow.Application.Internal.CommandServices;
using SmartFlow_Platform.SmartFlow.Application.Internal.QueryServices;
using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

namespace SmartFlow_Platform.SmartFlow.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
public class RegistroController : ControllerBase
{
    private readonly RegistroCommandService _registroCommandService;
    private readonly RegistroQueryService _registroQueryService;

    public RegistroController(RegistroCommandService registroCommandService, RegistroQueryService registroQueryService)
    {
        _registroCommandService = registroCommandService;
        _registroQueryService = registroQueryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _registroQueryService.GetAllRegistroAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _registroQueryService.GetRegistroByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(Registro registro)
    {
        await _registroCommandService.AddRegistroAsync(registro);
        return CreatedAtAction(nameof(Get), new { id = registro.Id }, registro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Registro registro)
    {
        registro.Id = id;
        await _registroCommandService.UpdateRegistroAsync(registro);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _registroCommandService.DeleteRegistroAsync(id);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.SmartFlow.Application.Internal.CommandServices;
using SmartFlow_Platform.SmartFlow.Application.Internal.QueryServices;
using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

namespace SmartFlow_Platform.SmartFlow.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
public class AlarmasController : ControllerBase
{
    
   private readonly AlarmasCommandService _alarmasCommandService;
   private readonly AlarmasQueryService _alarmasQueryService;

   public AlarmasController(AlarmasCommandService alarmasCommandService, AlarmasQueryService alarmasQueryService)
   {
       _alarmasCommandService = alarmasCommandService;
       _alarmasQueryService = alarmasQueryService;
   }
   
   [HttpGet]
   public async Task<IActionResult> GetAll() => Ok(await _alarmasQueryService.GetAllAlarmasAsync());

   [HttpGet("{id}")]
   public async Task<IActionResult> Get(int id) => Ok(await _alarmasQueryService.GetAlarmasByIdAsync(id));

   [HttpPost]
   public async Task<IActionResult> Create(Alarmas alarmas)
   {
       await _alarmasCommandService.AddAlarmasAsync(alarmas);
       return CreatedAtAction(nameof(Get), new { id = alarmas.Id }, alarmas);
   }

   [HttpPut("{id}")]
   public async Task<IActionResult> Update(int id, Alarmas alarmas)
   {
       alarmas.Id = id;
       await _alarmasCommandService.UpdateAlarmasAsync(alarmas);
       return NoContent();
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> Delete(int id)
   {
       await _alarmasCommandService.DeleteAlarmasAsync(id);
       return NoContent();
   }
}

using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.SmartFlow.Application.Internal.CommandServices;
using SmartFlow_Platform.SmartFlow.Application.Internal.QueryServices;
using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

namespace SmartFlow_Platform.SmartFlow.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserCommandService _userCommandService;
    private readonly UserQueryService _userQueryService;

    public UserController(UserCommandService userCommandService, UserQueryService userQueryService)
    {
        _userCommandService = userCommandService;
        _userQueryService = userQueryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _userQueryService.GetAllUsersAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _userQueryService.GetUserByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        await _userCommandService.AddUserAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        user.Id = id;
        await _userCommandService.UpdateUserAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userCommandService.DeleteUserAsync(id);
        return NoContent();
    }
}

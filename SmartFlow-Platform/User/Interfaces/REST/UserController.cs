using Microsoft.AspNetCore.Mvc;
using SmartFlow_Platform.User.Domain.Model.Commands;
using SmartFlow_Platform.User.Domain.Model.Queries;
using SmartFlow_Platform.User.Domain.Repositories;
using SmartFlow_Platform.User.Domain.Services;
using SmartFlow_Platform.User.Interfaces.REST.Resources;
using SmartFlow_Platform.User.Interfaces.REST.Transform;

namespace SmartFlow_Platform.User.Interfaces.REST;

using Domain.Model.Aggregates;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly IUserQueryService _queryService;
    private readonly IUserCommandService _commandService;

    public UserController(
        IUserRepository repository,
        IUserQueryService queryService,
        IUserCommandService commandService)
    {
        _repository = repository;
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _queryService.Handle(new GetAllUsersQuery());
        var resources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _queryService.Handle(new GetUserByIdQuery(id));
        if (user == null)
            return NotFound();

        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserResource resource)
    {
        var command = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await _commandService.Handle(command);

        if (user == null)
            return BadRequest("Error creating the user.");

        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, userResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User updatedUser)
    {
        var command = new UpdateUserCommand(id, updatedUser.Name, updatedUser.LastName, updatedUser.Email);
        var user = await _commandService.Handle(command);

        if (user == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand(id);
        var result = await _commandService.Handle(command);

        if (!result)
            return NotFound();

        return NoContent();
    }
}

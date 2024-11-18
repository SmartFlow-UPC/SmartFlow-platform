using SmartFlow_Platform.User.Domain.Model.Commands;

namespace SmartFlow_Platform.User.Domain.Services;

using Model.Aggregates;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
    Task<User?> Handle(UpdateUserCommand command);
    Task<bool> Handle(DeleteUserCommand command);
}
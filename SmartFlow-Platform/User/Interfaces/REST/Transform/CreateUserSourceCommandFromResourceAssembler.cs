using SmartFlow_Platform.User.Domain.Model.Commands;
using SmartFlow_Platform.User.Interfaces.REST.Resources;

namespace SmartFlow_Platform.User.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource) =>
        new CreateUserCommand(resource.Name, resource.LastName, resource.Email, resource.Password);
}
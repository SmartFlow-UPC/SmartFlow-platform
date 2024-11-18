using SmartFlow_Platform.Registros.Domain.Model.Commands;
using SmartFlow_Platform.Registros.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Registros.Interfaces.REST.Transform;

public static class CreateRegistroCommandFromResourceAssembler
{
    public static CreateRegistroCommand ToCommandFromResource(CreateRegistroResource resource) =>
        new CreateRegistroCommand(resource.Title, resource.Description, resource.Alto, resource.Status);
}
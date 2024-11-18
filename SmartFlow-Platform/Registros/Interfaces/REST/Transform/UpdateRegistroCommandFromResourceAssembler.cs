using SmartFlow_Platform.Registros.Domain.Model.Commands;
using SmartFlow_Platform.Registros.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Registros.Interfaces.REST.Transform;

public static class UpdateRegistroCommandFromResourceAssembler
{
    public static UpdateRegistroCommand ToCommandFromResource(UpdateRegistroResource resource) =>
        new UpdateRegistroCommand(resource.Id, resource.Title, resource.Description, resource.Alto, resource.Status);
}
using SmartFlow_Platform.Control.Domain.Model.Commands;
using SmartFlow_Platform.Control.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Control.Interfaces.REST.Transform;

public static class CreateControlCommandFromResourceAssembler
{
    public static CreateControlCommand ToCommandFromResource(CreateControlResource resource) =>
        new CreateControlCommand(resource.Producto, resource.Cantidad, resource.Peso, resource.Precio);
}
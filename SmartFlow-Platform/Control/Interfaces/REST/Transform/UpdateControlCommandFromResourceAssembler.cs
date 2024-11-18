using SmartFlow_Platform.Control.Domain.Model.Commands;
using SmartFlow_Platform.Control.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Control.Interfaces.REST.Transform;

public static class UpdateControlCommandFromResourceAssembler
{
    public static UpdateControlCommand ToCommandFromResource(UpdateControlResource resource) =>
        new UpdateControlCommand(resource.Id, resource.Producto, resource.Cantidad, resource.Peso, resource.Precio);
}
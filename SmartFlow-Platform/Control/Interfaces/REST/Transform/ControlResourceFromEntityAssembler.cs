using SmartFlow_Platform.Control.Domain.Model.Aggregates;
using SmartFlow_Platform.Control.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Control.Interfaces.REST.Transform;

using Domain.Model.Aggregates;

public static class ControlResourceFromEntityAssembler
{
    public static ControlResource ToResourceFromEntity(Control entity) =>
        new ControlResource(entity.Id, entity.Producto, entity.Cantidad, entity.Peso, entity.Precio);
}
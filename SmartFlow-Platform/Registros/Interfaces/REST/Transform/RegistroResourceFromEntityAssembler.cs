using SmartFlow_Platform.Registros.Domain.Model.Aggregates;
using SmartFlow_Platform.Registros.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Registros.Interfaces.REST.Transform;

public static class RegistroResourceFromEntityAssembler
{
    public static RegistroResource ToResourceFromEntity(Registro entity) =>
        new RegistroResource(entity.Id, entity.Title, entity.Description, entity.Alto, entity.Status);
}
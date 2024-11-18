using SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;
using SmartFlow_Platform.Alarmas.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Alarmas.Interfaces.REST.Transform;

public static class AlarmaResourceFromEntityAssembler
{
    public static AlarmaResource ToResourceFromEntity(Alarma entity) =>
        new AlarmaResource(entity.Id, entity.Dispositivo, entity.Tipo, entity.Valor, entity.Umbral, entity.Fecha, entity.Estado);
}
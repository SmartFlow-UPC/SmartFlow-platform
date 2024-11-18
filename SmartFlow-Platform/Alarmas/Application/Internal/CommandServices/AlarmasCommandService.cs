using SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;
using SmartFlow_Platform.Alarmas.Domain.Model.Commands;
using SmartFlow_Platform.Alarmas.Domain.Repositories;
using SmartFlow_Platform.Alarmas.Domain.Services;

namespace SmartFlow_Platform.Alarmas.Application.Internal.CommandServices;

public class AlarmasCommandService : IAlarmasCommandService
{
    private readonly IAlarmasRepository _repository;

    public AlarmasCommandService(IAlarmasRepository repository)
    {
        _repository = repository;
    }

    public async Task<Alarma?> Handle(CreateAlarmaCommand command)
    {
        var alarma = new Alarma(command.Dispositivo, command.Tipo, command.Valor, command.Umbral, command.Fecha, command.Estado);
        await _repository.AddAsync(alarma);
        return alarma;
    }

    public async Task<Alarma?> Handle(UpdateAlarmaCommand command)
    {
        var existingAlarma = await _repository.GetByIdAsync(command.Id);
        if (existingAlarma == null)
            throw new Exception("Alarma not found.");

        existingAlarma.Update(command.Dispositivo, command.Tipo, command.Valor, command.Umbral, command.Fecha, command.Estado);
        await _repository.UpdateAsync(existingAlarma);

        return existingAlarma;
    }

    public async Task<bool> Handle(DeleteAlarmaCommand command)
    {
        await _repository.DeleteAsync(command.Id);
        return true;
    }
}
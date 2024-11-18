using SmartFlow_Platform.Consumos.Domain.Model.Aggregates;
using SmartFlow_Platform.Consumos.Domain.Model.Commands;
using SmartFlow_Platform.Consumos.Domain.Repositories;
using SmartFlow_Platform.Consumos.Domain.Services;

namespace SmartFlow_Platform.Consumos.Application.Internal.CommandServices;

public class ConsumoCommandService : IConsumoCommandService
{
    private readonly IConsumoRepository _repository;

    public ConsumoCommandService(IConsumoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Consumo?> Handle(CreateConsumoCommand command)
    {
        var consumo = new Consumo(command.Aparato, command.Cantidad, command.PotenciaWatts);
        await _repository.AddAsync(consumo);
        return consumo;
    }

    public async Task<Consumo?> Handle(UpdateConsumoCommand command)
    {
        var existingConsumo = await _repository.GetByIdAsync(command.Id);
        if (existingConsumo == null) throw new Exception("Consumo not found.");

        existingConsumo.Update(command.Aparato, command.Cantidad, command.PotenciaWatts);
        await _repository.UpdateAsync(existingConsumo);

        return existingConsumo;
    }

    public async Task<bool> Handle(DeleteConsumoCommand command)
    {
        await _repository.DeleteAsync(command.Id);
        return true;
    }
}
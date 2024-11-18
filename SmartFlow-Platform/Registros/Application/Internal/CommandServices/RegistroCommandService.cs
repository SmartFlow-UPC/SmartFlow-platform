using SmartFlow_Platform.Registros.Domain.Model.Aggregates;
using SmartFlow_Platform.Registros.Domain.Model.Commands;
using SmartFlow_Platform.Registros.Domain.Repositories;
using SmartFlow_Platform.Registros.Domain.Services;

namespace SmartFlow_Platform.Registros.Application.Internal.CommandServices;

public class RegistroCommandService : IRegistroCommandService
{
    private readonly IRegistroRepository _repository;

    public RegistroCommandService(IRegistroRepository repository)
    {
        _repository = repository;
    }

    public async Task<Registro?> Handle(CreateRegistroCommand command)
    {
        var registro = new Registro(command.Title, command.Description, command.Alto, command.Status);
        await _repository.AddAsync(registro);
        return registro;
    }

    public async Task<Registro?> Handle(UpdateRegistroCommand command)
    {
        var existingRegistro = await _repository.GetByIdAsync(command.Id);
        if (existingRegistro == null) throw new Exception("Registro not found.");

        existingRegistro.Update(command.Title, command.Description, command.Alto, command.Status);
        await _repository.UpdateAsync(existingRegistro);

        return existingRegistro;
    }

    public async Task<bool> Handle(DeleteRegistroCommand command)
    {
        await _repository.DeleteAsync(command.Id);
        return true;
    }
}
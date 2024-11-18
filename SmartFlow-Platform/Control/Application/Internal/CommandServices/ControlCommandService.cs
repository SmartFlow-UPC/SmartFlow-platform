using SmartFlow_Platform.Control.Domain.Model.Commands;
using SmartFlow_Platform.Control.Domain.Repositories;
using SmartFlow_Platform.Control.Domain.Services;

namespace SmartFlow_Platform.Control.Application.Internal.CommandServices;

using Domain.Model.Aggregates;

public class ControlCommandService : IControlCommandService
{
    private readonly IControlRepository _repository;

    public ControlCommandService(IControlRepository repository)
    {
        _repository = repository;
    }

    public async Task<Control?> Handle(CreateControlCommand command)
    {
        var control = new Control(command.Producto, command.Cantidad, command.Peso, command.Precio);
        await _repository.AddAsync(control);
        return control;
    }

    public async Task<Control?> Handle(UpdateControlCommand command)
    {
        var existingControl = await _repository.GetByIdAsync(command.Id);
        if (existingControl == null) throw new Exception("Control not found.");

        existingControl.Update(command.Producto, command.Cantidad, command.Peso, command.Precio);
        await _repository.UpdateAsync(existingControl);

        return existingControl;
    }

    public async Task<bool> Handle(DeleteControlCommand command)
    {
        await _repository.DeleteAsync(command.Id);
        return true;
    }
}
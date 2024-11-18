using SmartFlow_Platform.Control.Domain.Model.Commands;

namespace SmartFlow_Platform.Control.Domain.Services;

using Model.Aggregates;

public interface IControlCommandService
{
    Task<Control?> Handle(CreateControlCommand command);
    Task<Control?> Handle(UpdateControlCommand command);
    Task<bool> Handle(DeleteControlCommand command);
}
using SmartFlow_Platform.Control.Domain.Model.Queries;

namespace SmartFlow_Platform.Control.Domain.Services;

using Model.Aggregates;

public interface IControlQueryService
{
    Task<IEnumerable<Control>> Handle(GetAllControlesQuery query);
    Task<Control?> Handle(GetControlByIdQuery query);
}
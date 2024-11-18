using SmartFlow_Platform.User.Domain.Model.Queries;

namespace SmartFlow_Platform.User.Domain.Services;

using Model.Aggregates;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByEmailQuery query);
}
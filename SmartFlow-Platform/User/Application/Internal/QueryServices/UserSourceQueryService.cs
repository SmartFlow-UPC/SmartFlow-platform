using SmartFlow_Platform.User.Domain.Model.Queries;
using SmartFlow_Platform.User.Domain.Repositories;
using SmartFlow_Platform.User.Domain.Services;

namespace SmartFlow_Platform.User.Application.Internal.QueryServices;

using Domain.Model.Aggregates;

public class UserQueryService(IUserRepository userRepository)
    : IUserQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.GetAllAsync();
    }

    /// <inheritdoc />
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.GetByIdAsync(query.Id);
    }

    /// <inheritdoc />
    public async Task<User?> Handle(GetUserByEmailQuery query)
    {
        return await userRepository.FindByEmailAsync(query.Email);
    }
}
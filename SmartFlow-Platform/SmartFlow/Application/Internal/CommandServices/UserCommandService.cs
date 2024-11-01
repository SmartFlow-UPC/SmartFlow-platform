using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;

namespace SmartFlow_Platform.SmartFlow.Application.Internal.CommandServices;

public class UserCommandService
{
    private readonly IUserRepository _userRepository;

    public UserCommandService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddUserAsync(User user) => await _userRepository.AddAsync(user);
    
    public async Task UpdateUserAsync(User user) => await _userRepository.UpdateAsync(user);
    
    public async Task DeleteUserAsync(int id) => await _userRepository.DeleteAsync(id);
}

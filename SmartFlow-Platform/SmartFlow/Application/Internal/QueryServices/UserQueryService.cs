using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;

namespace SmartFlow_Platform.SmartFlow.Application.Internal.QueryServices;

public class UserQueryService
{
    private readonly IUserRepository _userRepository;

    public UserQueryService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(int id) => await _userRepository.GetByIdAsync(id);
    
    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _userRepository.GetAllAsync();
}

public class RegistroQueryService
{
    private readonly IRegistroRepository _registroRepository;

    public RegistroQueryService(IRegistroRepository registroRepository)
    {
        _registroRepository = registroRepository;
    }

    public async Task<Registro> GetRegistroByIdAsync(int id) => await _registroRepository.GetByIdAsync(id);
    
    public async Task<IEnumerable<Registro>> GetAllRegistrosAsync() => await _registroRepository.GetAllAsync();
}

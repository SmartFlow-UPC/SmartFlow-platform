namespace SmartFlow_Platform.User.Domain.Repositories;

using Model.Aggregates;

public interface IUserRepository
{
    Task<User?> FindByEmailAsync(string email);
    Task<User?> GetByIdAsync(int id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
}
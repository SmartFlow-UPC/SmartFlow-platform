using SmartFlow_Platform.Shared.Domain.Repositories;
using SmartFlow_Platform.User.Domain.Repositories;
using SmartFlow_Platform.User.Domain.Services;
using SmartFlow_Platform.User.Domain.Model.Commands;

namespace SmartFlow_Platform.User.Application.Internal.CommandServices;

using Domain.Model.Aggregates;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var existingUser = await userRepository.FindByEmailAsync(command.Email);
        if (existingUser != null)
            throw new Exception("A user with this email already exists.");

        var newUser = new User(command.Name, command.LastName, command.Email, command.Password);
        try
        {
            await userRepository.AddAsync(newUser);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return newUser;
    }

    public async Task<User?> Handle(UpdateUserCommand command)
    {
        var user = await userRepository.GetByIdAsync(command.Id);
        if (user == null)
            throw new Exception("User not found.");

        user.Update(command.Name, command.LastName, command.Email);
        try
        {
            await userRepository.UpdateAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return user;
    }

    public async Task<bool> Handle(DeleteUserCommand command)
    {
        var user = await userRepository.GetByIdAsync(command.Id);
        if (user == null)
            throw new Exception("User not found.");

        try
        {
            await userRepository.DeleteAsync(command.Id);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}

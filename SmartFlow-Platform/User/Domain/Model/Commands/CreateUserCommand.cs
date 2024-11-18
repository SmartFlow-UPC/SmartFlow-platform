namespace SmartFlow_Platform.User.Domain.Model.Commands;

public record CreateUserCommand(string Name, string LastName, string Email, string Password);

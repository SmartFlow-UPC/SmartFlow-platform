namespace SmartFlow_Platform.User.Domain.Model.Commands;

public record UpdateUserCommand(int Id, string Name, string LastName, string Email);

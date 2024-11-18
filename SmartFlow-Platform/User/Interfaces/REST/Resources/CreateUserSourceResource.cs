namespace SmartFlow_Platform.User.Interfaces.REST.Resources;

public record CreateUserResource(string Name, string LastName, string Email, string Password);

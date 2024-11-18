namespace SmartFlow_Platform.Registros.Domain.Model.Commands;

public record UpdateRegistroCommand(int Id, string Title, string Description, bool Alto, string Status);

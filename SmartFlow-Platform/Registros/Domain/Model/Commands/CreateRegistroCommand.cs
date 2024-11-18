namespace SmartFlow_Platform.Registros.Domain.Model.Commands;

public record CreateRegistroCommand(string Title, string Description, bool Alto, string Status);

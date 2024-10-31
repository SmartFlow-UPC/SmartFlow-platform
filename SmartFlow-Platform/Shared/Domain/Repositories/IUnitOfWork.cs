namespace SmartFlow_Platform.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
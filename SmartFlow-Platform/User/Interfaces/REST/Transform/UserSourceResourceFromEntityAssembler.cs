using SmartFlow_Platform.User.Interfaces.REST.Resources;

namespace SmartFlow_Platform.User.Interfaces.REST.Transform;

using Domain.Model.Aggregates;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity) =>
        new UserResource(entity.Id, entity.Name, entity.LastName, entity.Email);
}
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Orders;
using RoutePlanning.Domain.Users;

namespace RoutePlanning.Application.Orders.Commands;

public sealed record CreateOrderCommand(
    double Weight,
    User.EntityId UserEntityId,
    FreightType.EntityId FreightEntityId,
    List<Connection.EntityId> Route);

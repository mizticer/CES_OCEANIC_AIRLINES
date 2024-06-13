using Netcompany.Net.Cqs.Commands;

namespace RoutePlanning.Application.Orders.Commands;

public sealed record CreateOrderCommand(
    double Weight,
    Guid UserEntityId,
    Guid FreightEntityId,
    List<Guid> Route) : ICommand;

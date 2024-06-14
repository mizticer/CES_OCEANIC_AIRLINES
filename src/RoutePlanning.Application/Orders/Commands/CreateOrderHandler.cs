using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Commands;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Locations.Services;
using RoutePlanning.Domain.Orders;
using RoutePlanning.Domain.Users;

namespace RoutePlanning.Application.Orders.Commands;

public sealed class CreateOrderHandler : ICommandHandler<CreateOrderCommand>
{
    private readonly IRepository<Connection> connections;
    private readonly IRepository<FreightType> freightTypes;
    private readonly IRepository<User> users;
    private readonly IRepository<Order> orders;

    public CreateOrderHandler(
        IRepository<Connection> connections,
        IRepository<FreightType> freightTypes,
        IRepository<User> users,
        IRepository<Order> orders)
    {
        this.connections = connections;
        this.freightTypes = freightTypes;
        this.users = users;
        this.orders = orders;
    }
    public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var createdAt = DateTime.Now;
        var route = new List<Connection>();
        foreach (var connection in command.Route)
        {
            var connectionId = new Connection.EntityId(connection);
            route.Add(await connections.FirstAsync(x => x.Id == connectionId, cancellationToken));
        }

        var distance = route.Sum(x => x.Distance.Value);
        var expectedTimeAtArrival = createdAt.AddHours(distance); // TODO - temporary solution
        var weight = new Weight(command.Weight);

        var freightType = await freightTypes.FirstAsync(x => x.Id == command.FreightEntityId, cancellationToken);
        var user = await users.FirstAsync(x => x.Id == command.UserEntityId, cancellationToken);
        var newOrder = Order.AddOrder(createdAt, expectedTimeAtArrival, weight, user, freightType, route);

        await orders.Add(newOrder, cancellationToken);
    }
}

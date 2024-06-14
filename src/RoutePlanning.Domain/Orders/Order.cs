using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Users;

namespace RoutePlanning.Domain.Orders;

public sealed class Order : AggregateRoot<Order>
{
    public Order(
        DateTime createdAt,
        DateTime expectedTimeOfArrival,
        Weight weight,
        User user,
        FreightType freightType)
    {
        CreatedAt = createdAt;
        ExpectedTimeOfArrival = expectedTimeOfArrival;
        Weight = weight;
        User = user;
        FreightType = freightType;
    }

    private Order()
    {
        User = null!;
        Weight = null!;
        FreightType = null!;
    }

    public DateTime CreatedAt { get; }
    public DateTime ExpectedTimeOfArrival { get; }
    public Weight Weight { get; set; }
    public FreightType FreightType { get; set; }
    public User User { get; init; }

    private readonly List<Connection> connections = [];
    public IReadOnlyCollection<Connection> Connections => connections.AsReadOnly();

    public static Order AddOrder(
        DateTime createdAt,
        DateTime expectedTimeOfArrival,
        Weight weight,
        User user,
        FreightType freightType,
        List<Connection> connections)
    {
        var order = new Order(createdAt, expectedTimeOfArrival, weight, user, freightType);
        order.connections.AddRange(connections);
        return new Order(createdAt, expectedTimeOfArrival, weight, user, freightType);
    }
}

using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Users;

namespace RoutePlanning.Domain.Orders;

public sealed class Order : AggregateRoot<Order>
{
    public Order(
        DateTime createdAt,
        DateTime expectedTimeOfArrival,
        Distance totalDistance,
        Price totalCost,
        Weight weight,
        User user,
        FreightType freightt)
    {
        CreatedAt = createdAt;
        ExpectedTimeOfArrival = expectedTimeOfArrival;
        TotalDistance = totalDistance;
        TotalCost = totalCost;
        Weight = weight;
        User = user;
        Freightt = freightt;
    }

    private Order()
    {
        TotalDistance = null!;
        TotalCost = null!;
        User = null!;
        Weight = null!;
        Freightt = null!;
    }

    public DateTime CreatedAt { get; }
    public DateTime ExpectedTimeOfArrival { get; }
    public Distance TotalDistance { get; set; }
    public Price TotalCost { get; set; }
    public Weight Weight { get; set; }
    public FreightType Freightt { get; set; }
    public User User { get; init; }

    private readonly List<Connection> connections = [];
    public IReadOnlyCollection<Connection> Connections => connections.AsReadOnly();
}

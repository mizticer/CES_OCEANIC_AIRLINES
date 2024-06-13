using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Domain.Orders;

public class Order : AggregateRoot<Order>
{
    public Order(
        DateTime createdAt,
        DateTime expectedTimeOfArrival,
        Distance totalDistance,
        Price totalPrice,
        List<Connection> connections)
    {
        CreatedAt = createdAt;
        ExpectedTimeOfArrival = expectedTimeOfArrival;
        TotalDistance = totalDistance;
        TotalPrice = totalPrice;
        Connections = connections;
    }

    public DateTime CreatedAt { get; }
    public DateTime ExpectedTimeOfArrival { get; }
    public Distance TotalDistance { get; }
    public Price TotalPrice { get; }
    public List<Connection> Connections { get; }
}

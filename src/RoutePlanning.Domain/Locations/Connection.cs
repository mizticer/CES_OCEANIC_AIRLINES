using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Source} --{Distance}--> {Destination}")]
public sealed class Connection : Entity<Connection>
{
    public Connection(Location source, Location destination, Distance distance, Price travelCost)
    {
        Source = source;
        Destination = destination;
        Distance = distance;
        TravelCost = travelCost;
    }

    public Location Source { get; private set; }

    public Location Destination { get; private set; }

    public Distance Distance { get; private set; }

    public Price TravelCost { get; init; }

    private readonly List<Order> orders = [];

    public IReadOnlyCollection<Order> Orders => orders.AsReadOnly();
}

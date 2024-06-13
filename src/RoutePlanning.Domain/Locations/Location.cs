using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Delivery;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Name}")]
public sealed class Location : AggregateRoot<Location>
{
    public Location(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    private readonly List<Connection> connections = new List<Connection>();

    public IReadOnlyCollection<Connection> Connections => connections.AsReadOnly();

    public Connection AddConnection(Location destination, Distance distance, double cost)
    {
        Connection connection = new Connection(this, destination, distance, cost);

        connections.Add(connection);

        return connection;
    }
}

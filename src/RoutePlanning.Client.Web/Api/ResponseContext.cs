using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Client.Web.Api;

public class ResponseContext
{
    public int cost { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public ResponseContext(int cost, Connection connection)
    {
        this.cost = cost;
        Source = connection.Source.Name;
        Destination = connection.Destination.Name;
    }
}

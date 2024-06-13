using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Locations.Queries.Connections;
public sealed class ConnectionQueryHandler : IQueryHandler<ConnectionQuery, List<Connection>>
{
    private readonly IQueryable<Connection> connections;

    public ConnectionQueryHandler(IQueryable<Connection> connections)
    {
        this.connections = connections;

    }
    public async Task<List<Connection>> Handle(ConnectionQuery request, CancellationToken cancellationToken)
    {
        return await connections.Include(x => x.Source).Include(x => x.Destination).ToListAsync(cancellationToken);
    }
}


using Netcompany.Net.Cqs.Queries;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Locations.Queries.Connections;
public sealed record ConnectionQuery() : IQuery<List<Connection>>;


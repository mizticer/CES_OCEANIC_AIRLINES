using Netcompany.Net.Cqs.Commands;
using Netcompany.Net.DomainDrivenDesign.Services;
using RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Application.Locations.Commands.GetConnections;
public sealed class GetConnectionsCommandHandler : ICommandHandler<GetConnectionsCommand>
{
    private DateTime dateFrom { get; set; }
    private DateTime dateTo { get; set; }
    private Weight weight { get; set; }
    private FreightType freightType { get; set; }


    public GetConnectionsCommandHandler(DateTime dateFrom, DateTime dateTo, double weight, string freightType)
    {
        this.dateFrom = dateFrom;
        this.dateTo = dateTo;
        this.weight = new Weight(weight);
        this.freightType = new FreightType(1, freightType);
    }

    public async Task Handle(GetConnectionsCommand command, CancellationToken cancellationToken)
    {
        if (freightType.FreightTypeName.Equals("Animal"))
        {
            return new List<Connection>().DefaultIfEmpty();
        }
        var connections = GetConnectionsFromDatabase();
        if (weight.Value)
        {

        }
        var locationA = await locations.FirstAsync(l => l.Id == command.LocationAId, cancellationToken);
        var locationB = await locations.FirstAsync(l => l.Id == command.LocationBId, cancellationToken);

        locationA.AddConnection(locationB, command.Distance, command.TravelCost);
        locationB.AddConnection(locationA, command.Distance, command.TravelCost);
    }
}

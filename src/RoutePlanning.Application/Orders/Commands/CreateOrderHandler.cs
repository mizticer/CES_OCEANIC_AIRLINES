using RoutePlanning.Domain.Locations.Services;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Application.Orders.Commands;

public sealed class CreateOrderHandler
{
    private readonly IShortestDistanceService shortestDistanceService;

    public CreateOrderHandler(IShortestDistanceService shortestDistanceService)
    {
        this.shortestDistanceService = shortestDistanceService;
    }
    public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var createdAt = DateTime.Now;
        var distance = command.Route.Select(x => x.Di)
        var expectedTimeAtArrival = create;
        var weight = new Weight(command.Weight);

        Order.AddOrder();

    }
}

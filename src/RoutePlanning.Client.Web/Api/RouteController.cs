using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;
using RoutePlanning.Client.Web.Authorization;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(nameof(TokenRequirement))]
public sealed class RoutesController : ControllerBase
{
    private readonly IMediator mediator;

    public RoutesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("[action]")]
    public Task<string> HelloWorld(DateTime dateFrom, DateTime dateTo, int weight, string type)
    {
        return Task.FromResult($"Hello World, {dateFrom}, {dateTo}, {weight}, {type}!");
    }
    [HttpGet("[action]")]
    public Task<List<Connection>> GetConnections(DateTime dateFrom, DateTime dateTo, double weight, string freightType)
    {
        var command = new 
    }

    [HttpPost("[action]")]
    public async Task AddTwoWayConnection(GetConnectionsCommand command)
    {
        await mediator.Send(command);
    }
}

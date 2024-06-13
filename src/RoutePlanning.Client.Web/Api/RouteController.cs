using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoutePlanning.Application.Locations.Queries.Connections;
using RoutePlanning.Application.Orders.Commands;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
//[Authorize(nameof(TokenRequirement))]
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
    public async Task<List<ResponseContext>> GetConnections(DateTime dateFrom, DateTime dateTo, double weight, string freightType)
    {
        var command = new ConnectionQuery();
        var connections = await mediator.Send(command);
        if (freightType.Equals("Live Animal"))
        {
            return new List<ResponseContext>();
        }

        var responses = new List<ResponseContext>();
        if (weight > 5)
        {
            foreach (var connection in connections)
            {
                var response = new ResponseContext(80, connection);
                responses.Add(response);
            }

            return responses;
        }

        if (weight < 1)
        {
            foreach (var connection in connections)
            {
                var response = new ResponseContext(40, connection);
                responses.Add(response);
            }

            return responses;

        }

        foreach (var connection in connections)
        {
            var response = new ResponseContext(60, connection);
            responses.Add(response);
        }

        return responses;

    }

    [HttpPost("[action]")]
    public async Task CreateOrder(CreateOrderCommand command)
    {
        await mediator.Send(command);
    }
}

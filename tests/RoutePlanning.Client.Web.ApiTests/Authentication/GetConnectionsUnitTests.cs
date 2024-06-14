using MediatR;
using Moq;
using RoutePlanning.Application.Locations.Queries.Connections;
using RoutePlanning.Client.Web.Api;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Client.Web.ApiTests.Authentication;
public class GetConnectionsUnitTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly RoutesController _routesController;

    public GetConnectionsUnitTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _routesController = new RoutesController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetConnections_WithLiveAnimalFreightType_ReturnsEmptyList()
    {
        // Arrange
        var dateFrom = new DateTime(2023, 1, 1);
        var dateTo = new DateTime(2023, 12, 31);
        var weight = 10.0;
        var freightType = "Live Animal";

        // Act
        var result = await _routesController.GetConnections(dateFrom, dateTo, weight, freightType);

        // Assert
        Assert.Empty(result);
    }
    [Fact]
    public async Task GetConnections_WithWeightGreaterThan5_ReturnsResponsesWithCost80()
    {
        // Arrange
        var dateFrom = new DateTime(2023, 1, 1);
        var dateTo = new DateTime(2023, 12, 31);
        var weight = 10.0;
        var freightType = "Fragile";

        var connections = new List<Connection>
        {
            new Connection(new Location("TANGER"), new Location("MARRAKESH"), new Distance(10),new Price(1)),
            new Connection(new Location("BAHREL GHAZAL"), new Location("SUAKIN"),new Distance(10),new Price(1))
        };
        _mediatorMock.Setup(m => m.Send(It.IsAny<ConnectionQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(connections);

        // Act
        var result = await _routesController.GetConnections(dateFrom, dateTo, weight, freightType);

        // Assert
        Assert.All(result, r => Assert.Equal(80, r.cost));
    }

    [Fact]
    public async Task GetConnections_WithWeightLessThan1_ReturnsResponsesWithCost40()
    {
        // Arrange
        var dateFrom = new DateTime(2023, 1, 1);
        var dateTo = new DateTime(2023, 12, 31);
        var weight = 0.5;
        var freightType = "Fragile";

        var connections = new List<Connection>
        {
             new Connection(new Location("TANGER"), new Location("MARRAKESH"), new Distance(10),new Price(1)),
            new Connection(new Location("BAHREL GHAZAL"), new Location("SUAKIN"),new Distance(10),new Price(1))
        };
        _mediatorMock.Setup(m => m.Send(It.IsAny<ConnectionQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(connections);

        // Act
        var result = await _routesController.GetConnections(dateFrom, dateTo, weight, freightType);

        // Assert
        Assert.All(result, r => Assert.Equal(40, r.cost));
    }

    [Fact]
    public async Task GetConnections_WithWeightBetween1And5_ReturnsResponsesWithCost60()
    {
        // Arrange
        var dateFrom = new DateTime(2023, 1, 1);
        var dateTo = new DateTime(2023, 12, 31);
        var weight = 3.0;
        var freightType = "Fragile";

        var connections = new List<Connection>
        {
             new Connection(new Location("TANGER"), new Location("MARRAKESH"), new Distance(10),new Price(1)),
            new Connection(new Location("BAHREL GHAZAL"), new Location("SUAKIN"),new Distance(10),new Price(1))
        };
        _mediatorMock.Setup(m => m.Send(It.IsAny<ConnectionQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(connections);

        // Act
        var result = await _routesController.GetConnections(dateFrom, dateTo, weight, freightType);

        // Assert
        Assert.All(result, r => Assert.Equal(60, r.cost));
    }
}


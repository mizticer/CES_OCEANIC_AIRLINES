using Netcompany.Net.Testing.Api;
using Newtonsoft.Json;
using RoutePlanning.Client.Web.Api;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Orders;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoutePlanning.Client.Web.ApiTests.Authentication;

public class TokenTests : IClassFixture<RoutePlanningApplicationFactory>
{
    private readonly RoutePlanningApplicationFactory factory;
    private readonly HttpClient client;

    public TokenTests(RoutePlanningApplicationFactory factory)
    {
        this.factory = factory;
        client = this.factory.HttpClient;
    }

    [Fact]
    public async void ShouldGetHelloWorld()
    {
        // Arrange
        var url = factory.GetRoute<Program, RoutesController>(x => x.HelloWorld);

        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Token", "TheSecretApiToken");

        var response = await client.SendAsync(request);

        // Assert
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("Hello World!", content);
    }
    [Fact]
    public async Task ShouldGetAllConnections()
    {
        // Arrange
        var url = "https://wa-oa-dk3.azurewebsites.net/api/routes/getconnections";

        var dateFrom = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var dateTo = new DateTime(2023, 12, 31, 23, 59, 59, DateTimeKind.Utc);
        var weight = 10.0;
        var freightType = "Fragile";

        var queryParams = $"?dateFrom={dateFrom:O}&dateTo={dateTo:O}&weight={weight}&freightType={freightType}";
        var fullUrl = $"{url}{queryParams}";

        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        // Define the expected responses
        var expectedResponses = @"
        [
            { ""cost"": 80, ""source"": ""TANGER"", ""destination"": ""MARRAKESH"" },
            { ""cost"": 80, ""source"": ""BAHREL GHAZAL"", ""destination"": ""SUAKIN"" },
            { ""cost"": 80, ""source"": ""KAP ST MARIE"", ""destination"": ""TAMATAVE"" },
            { ""cost"": 80, ""source"": ""KAP GUARDAFUI"", ""destination"": ""ADDIS ABEBA"" },
            { ""cost"": 80, ""source"": ""GULDKYSTEN"", ""destination"": ""SLAVEKUSTEN"" },
            { ""cost"": 80, ""source"": ""MOCAMBIQUE"", ""destination"": ""DRAGEBJERGET"" },
            { ""cost"": 80, ""source"": ""SUAKIN"", ""destination"": ""ADDIS ABEBA"" },
            { ""cost"": 80, ""source"": ""KAP GUARDAFUI"", ""destination"": ""ZANZIBAR"" },
            { ""cost"": 80, ""source"": ""MOCAMBIQUE"", ""destination"": ""KABALO"" },
            { ""cost"": 80, ""source"": ""SLAVEKUSTEN"", ""destination"": ""WADAI"" },
            { ""cost"": 80, ""source"": ""DRAGEBJERGET"", ""destination"": ""VICTORIAFALDEN"" },
            { ""cost"": 80, ""source"": ""TIMBUKTU"", ""destination"": ""SIERRA LEONE"" },
            { ""cost"": 80, ""source"": ""ZANZIBAR"", ""destination"": ""DE KANARISKE OER"" },
            { ""cost"": 80, ""source"": ""ADDIS ABEBA"", ""destination"": ""SUAKIN"" },
            { ""cost"": 80, ""source"": ""MARRAKESH"", ""destination"": ""TANGER"" },
            { ""cost"": 80, ""source"": ""DAKAR"", ""destination"": ""SIERRA LEONE"" },
            { ""cost"": 80, ""source"": ""TANGER"", ""destination"": ""TUNIS"" },
            { ""cost"": 80, ""source"": ""LUANDA"", ""destination"": ""CONGO"" },
            { ""cost"": 80, ""source"": ""SIERRA LEONE"", ""destination"": ""DAKAR"" },
            { ""cost"": 80, ""source"": ""BAHREL GHAZAL"", ""destination"": ""VICTORIASOEN"" },
            { ""cost"": 80, ""source"": ""ZANZIBAR"", ""destination"": ""KAP GUARDAFUI"" },
            { ""cost"": 80, ""source"": ""VICTORIAFALDEN"", ""destination"": ""HVALBUGTEN"" },
            { ""cost"": 80, ""source"": ""CONGO"", ""destination"": ""WADAI"" },
            { ""cost"": 80, ""source"": ""TRIPOLI"", ""destination"": ""OMDURMAN"" },
            { ""cost"": 80, ""source"": ""CAIRO"", ""destination"": ""OMDURMAN"" },
            { ""cost"": 80, ""source"": ""ST HELENA"", ""destination"": ""DE KANARISKE OER"" },
            { ""cost"": 80, ""source"": ""HVALBUGTEN"", ""destination"": ""KAPSTADEN"" },
            { ""cost"": 80, ""source"": ""SAHARA"", ""destination"": ""DAKAR"" },
            { ""cost"": 80, ""source"": ""TUNIS"", ""destination"": ""TANGER"" },
            { ""cost"": 80, ""source"": ""VICTORIASOEN"", ""destination"": ""KAPSTADEN"" },
            { ""cost"": 80, ""source"": ""TIMBUKTU"", ""destination"": ""GULDKYSTEN"" },
            { ""cost"": 80, ""source"": ""SIERRA LEONE"", ""destination"": ""TIMBUKTU"" },
            { ""cost"": 80, ""source"": ""KABALO"", ""destination"": ""MOCAMBIQUE"" },
            { ""cost"": 80, ""source"": ""DE KANARISKE OER"", ""destination"": ""ZANZIBAR"" },
            { ""cost"": 80, ""source"": ""CONGO"", ""destination"": ""LUANDA"" },
            { ""cost"": 80, ""source"": ""WADAI"", ""destination"": ""CONGO"" },
            { ""cost"": 80, ""source"": ""SUAKIN"", ""destination"": ""BAHREL GHAZAL"" },
            { ""cost"": 80, ""source"": ""TRIPOLI"", ""destination"": ""TUNIS"" },
            { ""cost"": 80, ""source"": ""KAPSTADEN"", ""destination"": ""VICTORIASOEN"" },
            { ""cost"": 80, ""source"": ""MARRAKESH"", ""destination"": ""SAHARA"" },
            { ""cost"": 80, ""source"": ""HVALBUGTEN"", ""destination"": ""VICTORIAFALDEN"" },
            { ""cost"": 80, ""source"": ""TUNIS"", ""destination"": ""TRIPOLI"" },
            { ""cost"": 80, ""source"": ""SLAVEKUSTEN"", ""destination"": ""GULDKYSTEN"" },
            { ""cost"": 80, ""source"": ""GULDKYSTEN"", ""destination"": ""TIMBUKTU"" },
            { ""cost"": 80, ""source"": ""OMDURMAN"", ""destination"": ""CAIRO"" },
            { ""cost"": 80, ""source"": ""ST HELENA"", ""destination"": ""KAP ST MARIE"" },
            { ""cost"": 80, ""source"": ""SAHARA"", ""destination"": ""MARRAKESH"" },
            { ""cost"": 80, ""source"": ""DAKAR"", ""destination"": ""SAHARA"" },
            { ""cost"": 80, ""source"": ""TAMATAVE"", ""destination"": ""KAP ST MARIE"" },
            { ""cost"": 80, ""source"": ""LUANDA"", ""destination"": ""KABALO"" },
            { ""cost"": 80, ""source"": ""VICTORIASOEN"", ""destination"": ""BAHREL GHAZAL"" },
            { ""cost"": 80, ""source"": ""OMDURMAN"", ""destination"": ""TRIPOLI"" },
            { ""cost"": 80, ""source"": ""VICTORIAFALDEN"", ""destination"": ""DRAGEBJERGET"" },
            { ""cost"": 80, ""source"": ""DE KANARISKE OER"", ""destination"": ""ST HELENA"" },
            { ""cost"": 80, ""source"": ""KAP ST MARIE"", ""destination"": ""ST HELENA"" },
            { ""cost"": 80, ""source"": ""DRAGEBJERGET"", ""destination"": ""MOCAMBIQUE"" },
            { ""cost"": 80, ""source"": ""CAIRO"", ""destination"": ""TUNIS"" },
            { ""cost"": 80, ""source"": ""WADAI"", ""destination"": ""SLAVEKUSTEN"" },
            { ""cost"": 80, ""source"": ""KABALO"", ""destination"": ""LUANDA"" },
            { ""cost"": 80, ""source"": ""TUNIS"", ""destination"": ""CAIRO"" },
            { ""cost"": 80, ""source"": ""KAPSTADEN"", ""destination"": ""HVALBUGTEN"" },
            { ""cost"": 80, ""source"": ""ADDIS ABEBA"", ""destination"": ""KAP GUARDAFUI"" }
        ]";

        var normalizedContent = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content));
        var normalizedExpectedResponses = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(expectedResponses));

        Assert.Equal(normalizedContent, normalizedExpectedResponses);
    }
}

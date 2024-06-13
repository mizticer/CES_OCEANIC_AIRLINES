using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Domain.Orders;

public sealed class FreightType : Entity<FreightType>
{
    public FreightType(Price fee, string freightTypeName)
    {
        Fee = fee;
        FreightTypeName = freightTypeName;
    }

    private FreightType()
    {
        Fee = null!;
        FreightTypeName = null!;
    }

    public Price Fee { get; set; }
    public string FreightTypeName { get; set; }
}

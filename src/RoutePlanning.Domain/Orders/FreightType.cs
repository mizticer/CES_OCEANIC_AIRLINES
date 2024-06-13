using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Orders;
public class FreightType : Entity<FreightType>
{
    public FreightType(Price fee, string freightTypeName)
    {
        Fee = fee;
        FreightTypeName = freightTypeName;
    }

    public Price Fee { get; set; }
    public string FreightTypeName { get; set; }
}

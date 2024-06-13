using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Orders;
public sealed record Price : IValueObject
{
    public Price(decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price must be 0 or greater.");
        }

        Value = price;
    }

    public decimal Value { get; init; }

    public static implicit operator Price(decimal price) => new(price);

    public static implicit operator decimal(Price distance) => distance.Value;
}

using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;
public sealed record Price : IValueObject
{
    public Price(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "A distance must be greater than zero");
        }

        Value = value;
    }

    public decimal Value { get; private set; }

    public static implicit operator Price(decimal distance) => new(distance);

    public static implicit operator decimal(Price distance) => distance.Value;
}

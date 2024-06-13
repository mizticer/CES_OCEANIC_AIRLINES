

using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;
public sealed record Price : IValueObject
{
    public Price(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "A distance must be greater than zero");
        }

        Value = value;
    }

    public int Value { get; private set; }

    public static implicit operator Price(int distance) => new(distance);

    public static implicit operator int(Price distance) => distance.Value;
}

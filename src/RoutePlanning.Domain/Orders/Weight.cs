using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Orders;
public sealed record Weight : IValueObject
{
    public Weight(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Weight must be 0 or greater.");
        }

        Value = value;
    }

    public decimal Value { get; private set; }

    public static implicit operator Weight(decimal weight) => new(weight);

    public static implicit operator decimal(Weight weight) => weight.Value;
}

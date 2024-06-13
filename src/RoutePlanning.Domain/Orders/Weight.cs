using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Orders;
public sealed record Weight : IValueObject
{
    public Weight(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(Weight)} must be zero or greater");
        }

        Value = value;
    }

    public double Value { get; private set; }

    public static implicit operator Weight(double weight) => new(weight);

    public static implicit operator double(Weight weight) => weight.Value;
}

using System;
using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;
namespace RoutePlanning.Domain.Delivery;

[DebuggerDisplay("{Value} dollars")]
public sealed record Cost : IValueObject
{
    public Cost(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "A cost must be greater than zero");
        }

        Value = value;
    }

    public double Value { get; private set; }

    public static implicit operator Cost(double cost) => new(cost);

    public static implicit operator double(Cost cost) => cost.Value;
}

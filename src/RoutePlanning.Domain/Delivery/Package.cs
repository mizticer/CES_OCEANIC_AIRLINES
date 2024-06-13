using System;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Delivery;

public sealed class Package : AggregateRoot<Package>
{
    public Package(string description, double weight)
    {
        Description = description;
        Weight = weight;
    }

    public string Description { get; set; }

    public double Weight { get; set; }
}

using System;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

public sealed class Country : AggregateRoot<Country>
{
    public Country(string name)
    {
        Name = name;
        Locations = new List<Location>();
    }

    public string Name { get; set; }

    public List<Location> Locations { get; }

    public void AddLocation(Location location)
    {
        Locations.Add(location);
    }
}

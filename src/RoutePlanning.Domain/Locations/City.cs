using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

public sealed class City : Entity<City>
{
    public City(string name, Country country)
    {
        Name = name;
        Country = country;
    }
    public string Name { get; init; }
    public Country Country { get; init; }
}

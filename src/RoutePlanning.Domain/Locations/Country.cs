using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;
public sealed class Country : Entity<Country>
{
    public Country(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}

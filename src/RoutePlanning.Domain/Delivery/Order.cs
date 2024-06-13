using Netcompany.Net.DomainDrivenDesign.Models;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Users;

namespace RoutePlanning.Domain.Delivery;

public sealed class Order : AggregateRoot<Order>
{
    private Order() { }

    public Order(User user, Package package, Location startLocation, Location endLocation, DateTime createdDate, DateTime endDate, double price, double distance, DeliveryStatus deliveryStatus)
    {
        User = user;
        Package = package;
        StartLocation = startLocation;
        EndLocation = endLocation;
        CreatedDate = createdDate;
        EndDate = endDate;
        Price = price;
        Distance = distance;
        DeliveryStatus = deliveryStatus;
    }

    public User User { get; set; } = default!;

    public Package Package { get; set; } = default!;

    public Location StartLocation { get; set; } = default!;

    public Location EndLocation { get; set; } = default!;

    public DateTime CreatedDate { get; set; }

    public DateTime EndDate { get; set; }

    public double Price { get; set; }

    public double Distance { get; set; }

    public DeliveryStatus DeliveryStatus { get; set; }
}

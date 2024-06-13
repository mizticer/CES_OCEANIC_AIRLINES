using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Infrastructure.Database.Orders;
internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.ExpectedTimeOfArrival);
        builder.OwnsOne(x => x.TotalDistance);
        builder.OwnsOne(x => x.TotalCost);
        builder.OwnsOne(x => x.Weight);
        builder.HasOne(x => x.Freightt);
        builder.HasOne(x => x.User).WithMany();
        builder.HasMany(x => x.Connections).WithMany(x => x.Orders);
    }
}

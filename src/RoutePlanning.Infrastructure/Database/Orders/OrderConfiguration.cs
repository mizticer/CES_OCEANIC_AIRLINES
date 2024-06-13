using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Infrastructure.Database.Orders;
public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ExpectedTimeOfArrival);
        builder.Property(x => x.TotalDistance);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.TotalPrice);
        builder.HasMany(x => x.Connections).WithMany();
    }
}

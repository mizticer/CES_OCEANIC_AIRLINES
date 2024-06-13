using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Delivery;

namespace RoutePlanning.Infrastructure.Database.Delivery;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Package)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.StartLocation)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.EndLocation)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Distance)
            .IsRequired();

        builder.Property(x => x.DeliveryStatus)
            .IsRequired();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Infrastructure.Database.Locations;

public sealed class ConnectionConfiguration : IEntityTypeConfiguration<Connection>
{
    public void Configure(EntityTypeBuilder<Connection> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Source)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Destination)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction); ;

        builder.OwnsOne(x => x.Distance);
        builder.OwnsOne(x => x.TravelCost);

        builder.HasMany(x => x.Orders).WithMany(x => x.Connections);
    }
}

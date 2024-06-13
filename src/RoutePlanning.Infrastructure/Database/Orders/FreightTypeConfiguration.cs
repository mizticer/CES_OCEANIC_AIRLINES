using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Orders;

namespace RoutePlanning.Infrastructure.Database.Orders;
internal class FreightTypeConfiguration : IEntityTypeConfiguration<FreightType>
{
    public void Configure(EntityTypeBuilder<FreightType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FreightTypeName);
        builder.OwnsOne(x => x.Fee);
    }
}

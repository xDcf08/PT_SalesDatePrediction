using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codifico.SalesDatePrediction.Persistence.Configuration
{
    public class OrderDetailsConfiguration
    {
        public OrderDetailsConfiguration(EntityTypeBuilder<OrderDetailsEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.OrderId);
            entityTypeBuilder.Property(x => x.Qty).IsRequired();
            entityTypeBuilder.Property(x => x.UnitPrice).IsRequired();
            entityTypeBuilder.Property(x => x.Discount).IsRequired();

            entityTypeBuilder.HasMany(x => x.Products)
                .WithOne(x => x.OrderDetail)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

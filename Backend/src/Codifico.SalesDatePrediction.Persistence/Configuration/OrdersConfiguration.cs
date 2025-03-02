using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codifico.SalesDatePrediction.Persistence.Configuration
{
    public class OrdersConfiguration
    {
        public OrdersConfiguration(EntityTypeBuilder<OrdersEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.OrderId);
            entityTypeBuilder.Property(x => x.OrderDate).IsRequired();
            entityTypeBuilder.Property(x => x.RequiredDate).IsRequired();
            entityTypeBuilder.Property(x => x.ShippedDate).IsRequired();
            entityTypeBuilder.Property(x => x.Freight).IsRequired();
            entityTypeBuilder.Property(x => x.ShipName).HasMaxLength(40).IsRequired();
            entityTypeBuilder.Property(x => x.ShipAddress).HasMaxLength(60).IsRequired();
            entityTypeBuilder.Property(x => x.ShipCity).HasMaxLength(15).IsRequired();
            entityTypeBuilder.Property(x => x.ShipRegion).HasMaxLength(15);
            entityTypeBuilder.Property(x => x.ShipPostalCode).HasMaxLength(15);
            entityTypeBuilder.Property(x => x.ShipCountry).HasMaxLength(15);

            entityTypeBuilder.HasMany(x => x.Employees)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.EmpId);

            entityTypeBuilder.HasMany(x => x.Customers)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.CustId);

            entityTypeBuilder.HasMany(x => x.Shippers)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.ShipperId);
        }
    }
}

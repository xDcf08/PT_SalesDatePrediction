using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codifico.SalesDatePrediction.Persistence.Configuration
{
    public class ProductsConfiguration
    {
        public ProductsConfiguration(EntityTypeBuilder<ProductsEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.ProductId);
            entityTypeBuilder.Property(x => x.ProductName).HasMaxLength(40).IsRequired();
            entityTypeBuilder.Property(x => x.UnitPrice).IsRequired();
            entityTypeBuilder.Property(x => x.Discontinued).IsRequired();

            entityTypeBuilder.HasMany(x => x.Suppliers)
                .WithOne(x => x.Products)
                .HasForeignKey(x => x.SupplierId);

            entityTypeBuilder.HasMany(x => x.Categories)
                .WithOne(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}

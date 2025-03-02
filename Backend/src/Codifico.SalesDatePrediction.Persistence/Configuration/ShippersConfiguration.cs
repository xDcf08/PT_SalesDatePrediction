using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codifico.SalesDatePrediction.Persistence.Configuration
{
    public class ShippersConfiguration
    {
        public ShippersConfiguration(EntityTypeBuilder<ShippersEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.ShipperId);
            entityTypeBuilder.Property(x => x.CompanyName).HasMaxLength(40).IsRequired();
            entityTypeBuilder.Property(x => x.Phone).HasMaxLength(24).IsRequired();
        }
    }
}

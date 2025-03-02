using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codifico.SalesDatePrediction.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.CustId);
            entityTypeBuilder.Property(x => x.CompanyName).HasMaxLength(40).IsRequired();
            entityTypeBuilder.Property(x => x.ContactName).HasMaxLength(30).IsRequired();
            entityTypeBuilder.Property(x => x.ContactTitle).HasMaxLength(30).IsRequired();
            entityTypeBuilder.Property(x => x.Address).HasMaxLength(60).IsRequired();
            entityTypeBuilder.Property(x => x.City).HasMaxLength(15).IsRequired();
            entityTypeBuilder.Property(x => x.Region).HasMaxLength(15);
            entityTypeBuilder.Property(x => x.PostalCode).HasMaxLength(10);
            entityTypeBuilder.Property(x => x.Country).HasMaxLength(15).IsRequired();
            entityTypeBuilder.Property(x => x.Phone).HasMaxLength(24).IsRequired();
            entityTypeBuilder.Property(x => x.Fax).HasMaxLength(24);
        }
    }
}

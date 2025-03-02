using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codifico.SalesDatePrediction.Persistence.Configuration
{
    public class SuppliersConfiguration
    {
        public SuppliersConfiguration(EntityTypeBuilder<SuppliersEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.SupplierId);
            entityTypeBuilder.Property(x => x.CompanyName).HasMaxLength(40).IsRequired();
            entityTypeBuilder.Property(x => x.ContactName).HasMaxLength(40).IsRequired();
            entityTypeBuilder.Property(x => x.ContactTitle).HasMaxLength(40).IsRequired();
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

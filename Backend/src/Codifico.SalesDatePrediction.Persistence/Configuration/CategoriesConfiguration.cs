using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codifico.SalesDatePrediction.Persistence.Configuration
{
    public class CategoriesConfiguration
    {
        public CategoriesConfiguration(EntityTypeBuilder<CategoriesEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.CategoryId);
            entityTypeBuilder.Property(x => x.CategoryName).HasMaxLength(15).IsRequired();
            entityTypeBuilder.Property(x => x.Description).HasMaxLength(200).IsRequired();
        }
    }
}

using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codifico.SalesDatePrediction.Persistence.Configuration
{
    public class EmployeesConfiguration
    {
        public EmployeesConfiguration(EntityTypeBuilder<EmployeesEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.EmpId);
            entityTypeBuilder.Property(x => x.LastName).HasMaxLength(20).IsRequired();
            entityTypeBuilder.Property(x => x.FirstName).HasMaxLength(10).IsRequired();
            entityTypeBuilder.Property(x => x.Title).HasMaxLength(30).IsRequired();
            entityTypeBuilder.Property(x => x.TitleOfCourtesy).HasMaxLength(25).IsRequired();
            entityTypeBuilder.Property(x => x.Birthdate).IsRequired();
            entityTypeBuilder.Property(x => x.HireDate).IsRequired();
            entityTypeBuilder.Property(x => x.Address).HasMaxLength(60).IsRequired();
            entityTypeBuilder.Property(x => x.City).HasMaxLength(15).IsRequired();
            entityTypeBuilder.Property(x => x.Region).HasMaxLength(15);
            entityTypeBuilder.Property(x => x.PostalCode).HasMaxLength(10);
            entityTypeBuilder.Property(x => x.Country).HasMaxLength(15).IsRequired();
            entityTypeBuilder.Property(x => x.Phone).HasMaxLength(24).IsRequired();
            entityTypeBuilder.Property(x => x.Mgrid);
        }
    }
}

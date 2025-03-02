using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Codifico.SalesDatePrediction.Application.DataBase
{
    public interface IApplicationDbContext
    {
        DbSet<CustomerEntity> Customers { get; set; }
        DbSet<EmployeesEntity> Employees { get; set; }
        DbSet<OrderDetailsEntity> OrderDatail { get; set; }
        DbSet<OrdersEntity> Orders { get; set; }
        DbSet<ProductsEntity> Product { get; set; }
        DbSet<ShippersEntity> Shipper { get; set; }
        Task<bool> SaveAsync();

        DatabaseFacade Database { get; }
    }
}

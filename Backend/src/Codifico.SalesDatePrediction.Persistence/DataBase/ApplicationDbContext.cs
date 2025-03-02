using Codifico.SalesDatePrediction.Application.DataBase;
using Codifico.SalesDatePrediction.Domain.Entities;
using Codifico.SalesDatePrediction.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Codifico.SalesDatePrediction.Persistence.DataBase
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        {
            Database = base.Database;
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<EmployeesEntity> Employees { get; set; }
        public DbSet<OrderDetailsEntity> OrderDatail { get; set; }
        public DbSet<OrdersEntity> Orders { get; set; }
        public DbSet<ProductsEntity> Product { get; set; }
        public DbSet<ShippersEntity> Shipper { get; set; }
        public override DatabaseFacade Database { get; }
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new CategoriesConfiguration(modelBuilder.Entity<CategoriesEntity>().ToTable("Categories", "Production"));
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>().ToTable("Customers", "Sales"));
            new EmployeesConfiguration(modelBuilder.Entity<EmployeesEntity>().ToTable("Employees", "HR"));
            new OrderDetailsConfiguration(modelBuilder.Entity<OrderDetailsEntity>().ToTable("OrderDetails", "Sales"));
            new OrdersConfiguration(modelBuilder.Entity<OrdersEntity>().ToTable("Orders", "Sales"));
            new ProductsConfiguration(modelBuilder.Entity<ProductsEntity>().ToTable("Products", "Production"));
            new ShippersConfiguration(modelBuilder.Entity<ShippersEntity>().ToTable("Shippers", "Sales"));
            new SuppliersConfiguration(modelBuilder.Entity<SuppliersEntity>().ToTable("Suppliers", "Production"));
        }
    }
}

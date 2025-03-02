using Codifico.SalesDatePrediction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codifico.SalesDatePrediction.Application.DataBase.Orders.Commands.CreateOrderWithProduct
{
    public class CreateOrderWithProductCommands : ICreateOrderWithProductCommands
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderWithProductCommands(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateOrderWithProductDTO> ExecuteAsync(CreateOrderWithProductDTO model)
        {
            using var tran = await _context.Database.BeginTransactionAsync();
            try
            {
                var Emp = await _context.Employees.AnyAsync(x => x.EmpId == model.EmpId);
                var Cust = await _context.Customers.AnyAsync(x => x.CustId == model.CustId);
                var Ship = await _context.Shipper.AnyAsync(x => x.ShipperId == model.ShipperId);

                if (Emp && Cust && Ship)
                    throw new Exception("Hubo un error al validar el empleado o el cliente o el repartidor");

                var OrderEntity = new OrdersEntity
                {
                    EmpId = model.EmpId,
                    CustId = model.CustId,
                    ShipperId = model.ShipperId,
                    ShipName = model.ShipName,
                    ShipAddress = model.ShipAdress,
                    ShipCity = model.ShipCity,
                    OrderDate = model.OrderDate,
                    RequiredDate = model.RequiredDate,
                    ShippedDate = model.ShippedDate,
                    Freight = model.Freight,
                    ShipCountry = model.ShipCountry
                };

                _context.Orders.Add(OrderEntity);
                if (await _context.SaveAsync())
                {
                    var orderId = OrderEntity.OrderId;

                    var OrderDetailEntity = new OrderDetailsEntity
                    {
                        OrderId = orderId,
                        ProductId = model.ProductId,
                        UnitPrice = model.UnitPrice,
                        Qty = model.Qty,
                        Discount = model.Discount,
                    };

                }

                await tran.CommitAsync();
                return model;
            }
            catch (Exception ex)
            {
                await tran.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}

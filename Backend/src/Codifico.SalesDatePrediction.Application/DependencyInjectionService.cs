using AutoMapper;
using Codifico.SalesDatePrediction.Application.Configuration;
using Codifico.SalesDatePrediction.Application.DataBase.Customer.Queries.GetClientByLastOrderDateAndNextPredictedOrder;
using Codifico.SalesDatePrediction.Application.DataBase.Employee.Queries.GetAllEmployees;
using Codifico.SalesDatePrediction.Application.DataBase.Orders.Commands.CreateOrderWithProduct;
using Codifico.SalesDatePrediction.Application.DataBase.Orders.Queries.GetOrdersByCustomer;
using Codifico.SalesDatePrediction.Application.DataBase.Products.Queries.GetAllProducts;
using Codifico.SalesDatePrediction.Application.DataBase.Shippers.Queries.GetAllShippers;
using Codifico.SalesDatePrediction.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Codifico.SalesDatePrediction.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            var mapper = new MapperConfiguration( config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            services.AddScoped<IGetClientWithLastOrderDateAndNextPredictedOrderQuery, GetClientWithLastOrderDateAndNextPredictedOrderQuery>();
            services.AddScoped<IGetOrdersByCustomerQuery, GetOrdersByCustomerQuery>();
            services.AddScoped<IGetAllEmployeesQuery, GetAllEmployeesQuery>();
            services.AddScoped<IGetAllShippersQuery, GetAllShippersQuery>();
            services.AddScoped<IGetAllProductsQuery, GetAllProductsQuery>();
            services.AddScoped<ICreateOrderWithProductCommands, CreateOrderWithProductCommands>();

            #region Validators
            services.AddScoped<IValidator<CreateOrderWithProductDTO>, CreateOrderValidator>();
            #endregion

            return services;
        }
    }
}

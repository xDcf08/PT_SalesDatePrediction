using AutoMapper;
using Codifico.SalesDatePrediction.Application.DataBase.Employee.Queries.GetAllEmployees;
using Codifico.SalesDatePrediction.Application.DataBase.Orders.Queries.GetOrdersByCustomer;
using Codifico.SalesDatePrediction.Application.DataBase.Products.Queries.GetAllProducts;
using Codifico.SalesDatePrediction.Application.DataBase.Shippers.Queries.GetAllShippers;
using Codifico.SalesDatePrediction.Domain.Entities;

namespace Codifico.SalesDatePrediction.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OrdersEntity, GetOrdersByCustomerDTO>().ReverseMap();
            CreateMap<EmployeesEntity, GetAllEmployeesDTO>().ReverseMap();
            CreateMap<ShippersEntity, GetAllShippersDTO>().ReverseMap();
            CreateMap<ProductsEntity, GetAllProductsDTO>().ReverseMap();
        }
    }
}

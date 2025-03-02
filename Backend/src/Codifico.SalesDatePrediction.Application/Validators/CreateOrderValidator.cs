using Codifico.SalesDatePrediction.Application.DataBase.Orders.Commands.CreateOrderWithProduct;
using FluentValidation;

namespace Codifico.SalesDatePrediction.Application.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderWithProductDTO>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.EmpId).NotNull().NotEmpty();
            RuleFor(x => x.CustId).NotNull().NotEmpty();
            RuleFor(x => x.OrderDate).NotNull().NotEmpty();
            RuleFor(x => x.RequiredDate).NotNull().NotEmpty();
            RuleFor(x => x.ShipperId).NotNull().NotEmpty();
            RuleFor(x => x.Freight).NotNull().NotEmpty();
            RuleFor(x => x.ShipName).NotNull().NotEmpty().MaximumLength(40);
            RuleFor(x => x.ShipAddress).NotNull().NotEmpty().MaximumLength(60);
            RuleFor(x => x.ShipCity).NotNull().NotEmpty().MaximumLength(15);
            RuleFor(x => x.ShipCountry).NotNull().NotEmpty().MaximumLength(15);
            RuleFor(x => x.ProductId).NotNull().NotEmpty();
            RuleFor(x => x.UnitPrice).NotNull().NotEmpty();
            RuleFor(x => x.Qty).NotNull().NotEmpty();
            RuleFor(x => x.Discount).NotNull().NotEmpty();
        }
    }
}

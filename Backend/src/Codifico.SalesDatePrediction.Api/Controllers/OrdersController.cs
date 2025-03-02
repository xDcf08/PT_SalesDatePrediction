using Codifico.SalesDatePrediction.Application.DataBase.Orders.Commands.CreateOrderWithProduct;
using Codifico.SalesDatePrediction.Application.DataBase.Orders.Queries.GetOrdersByCustomer;
using Codifico.SalesDatePrediction.Application.Exceptions;
using Codifico.SalesDatePrediction.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Codifico.SalesDatePrediction.Api.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class OrdersController : ControllerBase
    {
        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder(
            [FromBody] CreateOrderWithProductDTO model,
            [FromServices] ICreateOrderWithProductCommands createOrderWithProductCommands,
            [FromServices] IValidator<CreateOrderWithProductDTO> validator
            )
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            await createOrderWithProductCommands.ExecuteAsync(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created));
        }

        [HttpGet("get-orders-by-customer/{custId}")]
        public async Task<IActionResult> OrdersByCustomer(
            int custId,
            [FromServices] IGetOrdersByCustomerQuery ordersByCustomerQuery)
        {
            if (custId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await ordersByCustomerQuery.ExecuteAsync(custId);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}

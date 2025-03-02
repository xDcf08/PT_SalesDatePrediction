using Codifico.SalesDatePrediction.Application.DataBase.Customer.Queries.GetClientByLastOrderDateAndNextPredictedOrder;
using Codifico.SalesDatePrediction.Application.Exceptions;
using Codifico.SalesDatePrediction.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Codifico.SalesDatePrediction.Api.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        [HttpGet("get-client-with-lastOrderDate-and-nextPredictedOrder")]
        public async Task<IActionResult> GetClientWithLastOrderDateAndNextPredictedOrder(
            [FromServices] IGetClientWithLastOrderDateAndNextPredictedOrderQuery getClientWithLastOrderDateAndNextPredictedOrderQuery)
        {
            var data = await getClientWithLastOrderDateAndNextPredictedOrderQuery.ExecuteAsync();

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}

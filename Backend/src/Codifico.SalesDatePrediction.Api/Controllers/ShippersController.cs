using Codifico.SalesDatePrediction.Application.DataBase.Shippers.Queries.GetAllShippers;
using Codifico.SalesDatePrediction.Application.Exceptions;
using Codifico.SalesDatePrediction.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Codifico.SalesDatePrediction.Api.Controllers
{
    [Route("api/v1/shippers")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ShippersController : ControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllShippers(
            [FromServices] IGetAllShippersQuery getAllShippersQuery)
        {
            var data = await getAllShippersQuery.ExecuteAsync();

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}

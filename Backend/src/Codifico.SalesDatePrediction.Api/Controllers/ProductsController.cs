using Codifico.SalesDatePrediction.Application.DataBase.Products.Queries.GetAllProducts;
using Codifico.SalesDatePrediction.Application.Exceptions;
using Codifico.SalesDatePrediction.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Codifico.SalesDatePrediction.Api.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ProductsController : ControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllShippers(
            [FromServices] IGetAllProductsQuery getAllProductsQuery)
        {
            var data = await getAllProductsQuery.ExecuteAsync();

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}

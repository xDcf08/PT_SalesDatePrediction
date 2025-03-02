using Codifico.SalesDatePrediction.Application.DataBase.Employee.Queries.GetAllEmployees;
using Codifico.SalesDatePrediction.Application.Exceptions;
using Codifico.SalesDatePrediction.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Codifico.SalesDatePrediction.Api.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllEmployees(
            [FromServices] IGetAllEmployeesQuery getAllEmployeesQuery)
        {
            var data = await getAllEmployeesQuery.ExecuteAsync();

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}

using Codifico.SalesDatePrediction.Api.Controllers;
using Codifico.SalesDatePrediction.Application.DataBase.Employee.Queries.GetAllEmployees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Codifico.SalesDatePrediction.Test.Employee
{
    public class GetAllEmployeesTest
    {
        private readonly Mock<IGetAllEmployeesQuery> _mockService;
        private readonly CustomerController _controller;
        public GetAllEmployeesTest()
        {
            _mockService = new Mock<IGetAllEmployeesQuery>();
            _controller = new CustomerController();
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsGetAllEmployees()
        {
            var empleadosMock = new List<GetAllEmployeesDTO>
            {
                new GetAllEmployeesDTO
                {
                    EmpId = 1,
                    FullName = "Sara Davis"
                },
                new GetAllEmployeesDTO
                {
                    EmpId = 2,
                    FullName = "Don Funk"
                },
                new GetAllEmployeesDTO
                {
                    EmpId = 3,
                    FullName = "Judy Lew"
                }
            };

            _mockService.Setup(x => x.ExecuteAsync()).ReturnsAsync(empleadosMock);

            // Act Llamamos al método de la clase
            var resultado = await _mockService.Object.ExecuteAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count);
            Assert.Equal(1, resultado[0].EmpId);
            Assert.Equal("Sara Davis", resultado[0].FullName);
        }
    }
}

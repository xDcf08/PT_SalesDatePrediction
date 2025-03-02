using Codifico.SalesDatePrediction.Api.Controllers;
using Codifico.SalesDatePrediction.Application.DataBase.Customer.Queries.GetClientByLastOrderDateAndNextPredictedOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Codifico.SalesDatePrediction.Test.Customer
{
    public class GetCustomersWithOrderPredictionQueryTests
    {
        private readonly Mock<IGetClientWithLastOrderDateAndNextPredictedOrderQuery> _mockRepo;
        private readonly CustomerController _controller;
        public GetCustomersWithOrderPredictionQueryTests()
        {
            _mockRepo = new Mock<IGetClientWithLastOrderDateAndNextPredictedOrderQuery>();
            _controller = new CustomerController();
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsCustomersWithPredictedOrders()
        {
            // Arrange: Simulamos datos de prueba
            var clientesMock = new List<GetClientWithLastOrderDateAndNextPredictedOrderDTO>
            {
                new GetClientWithLastOrderDateAndNextPredictedOrderDTO
                {
                    CustomerName = "Cliente 1",
                    LastOrderDate = new DateTime(2024, 3, 1, 12, 0, 0),
                    NextPredictedOrder = "2024-04-01 12:00:00"
                },
                new GetClientWithLastOrderDateAndNextPredictedOrderDTO
                {
                    CustomerName = "Cliente 2",
                    LastOrderDate = new DateTime(2024, 2, 15, 12, 0, 0),
                    NextPredictedOrder = "2024-03-15 12:00:00"
                }
            };

            _mockRepo.Setup(repo => repo.ExecuteAsync()).ReturnsAsync(clientesMock);

            // Act Llamamos al método de la clase
            var resultado = await _mockRepo.Object.ExecuteAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count);
            Assert.Equal("Cliente 1", resultado[0].CustomerName);
            Assert.Equal("2024-04-01 12:00:00", resultado[0].NextPredictedOrder);
        }

        [Fact]
        public async Task GetClientWithLastOrderDateAndNextPredictedOrder_Returns200Ok_WithData()
        {
            // Arrange: Simulamos datos de prueba
            var clientesMock = new List<GetClientWithLastOrderDateAndNextPredictedOrderDTO>
            {
                new GetClientWithLastOrderDateAndNextPredictedOrderDTO
                {
                    CustomerName = "Cliente 1",
                    LastOrderDate = new DateTime(2024, 3, 1, 12, 0, 0),
                    NextPredictedOrder = "2024-04-01 12:00:00"
                }
            };

            _mockRepo.Setup(service => service.ExecuteAsync()).ReturnsAsync(clientesMock);

            // Act: Llamamos al método del controlador
            var result = await _controller.GetClientWithLastOrderDateAndNextPredictedOrder(_mockRepo.Object);

            // Assert: Verificamos que la respuesta sea 200 OK
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.NotNull(objectResult.Value);
        }
    }
}

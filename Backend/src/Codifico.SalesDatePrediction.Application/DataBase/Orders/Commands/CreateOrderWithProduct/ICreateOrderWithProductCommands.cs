namespace Codifico.SalesDatePrediction.Application.DataBase.Orders.Commands.CreateOrderWithProduct
{
    public interface ICreateOrderWithProductCommands
    {
        Task<CreateOrderWithProductDTO> ExecuteAsync(CreateOrderWithProductDTO model);
    }
}

namespace Codifico.SalesDatePrediction.Application.DataBase.Orders.Queries.GetOrdersByCustomer
{
    public interface IGetOrdersByCustomerQuery
    {
        Task<List<GetOrdersByCustomerDTO>> ExecuteAsync(int custId);
    }
}

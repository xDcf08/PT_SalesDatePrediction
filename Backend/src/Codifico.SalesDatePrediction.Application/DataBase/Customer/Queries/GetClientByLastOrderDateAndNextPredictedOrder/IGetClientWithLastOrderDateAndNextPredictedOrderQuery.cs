namespace Codifico.SalesDatePrediction.Application.DataBase.Customer.Queries.GetClientByLastOrderDateAndNextPredictedOrder
{
    public interface IGetClientWithLastOrderDateAndNextPredictedOrderQuery
    {
        Task<List<GetClientWithLastOrderDateAndNextPredictedOrderDTO>> ExecuteAsync();
    }
}

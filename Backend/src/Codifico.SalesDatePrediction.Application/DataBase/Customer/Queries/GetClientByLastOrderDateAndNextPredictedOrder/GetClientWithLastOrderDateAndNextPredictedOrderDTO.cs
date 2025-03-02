namespace Codifico.SalesDatePrediction.Application.DataBase.Customer.Queries.GetClientByLastOrderDateAndNextPredictedOrder
{
    public class GetClientWithLastOrderDateAndNextPredictedOrderDTO
    {
        public int custId { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public string? NextPredictedOrder { get; set; }
    }
}

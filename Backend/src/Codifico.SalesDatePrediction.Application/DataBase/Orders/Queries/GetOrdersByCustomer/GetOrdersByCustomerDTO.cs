namespace Codifico.SalesDatePrediction.Application.DataBase.Orders.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerDTO
    {
        public int OrderId { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
    }
}

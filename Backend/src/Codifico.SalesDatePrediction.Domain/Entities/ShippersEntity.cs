namespace Codifico.SalesDatePrediction.Domain.Entities
{
    public class ShippersEntity
    {
        public int ShipperId { get; set; }
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
        public OrdersEntity Order { get; set; }

    }
}

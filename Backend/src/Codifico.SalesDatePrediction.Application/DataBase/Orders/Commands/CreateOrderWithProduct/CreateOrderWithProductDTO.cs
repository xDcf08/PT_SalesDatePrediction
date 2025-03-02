namespace Codifico.SalesDatePrediction.Application.DataBase.Orders.Commands.CreateOrderWithProduct
{
    public class CreateOrderWithProductDTO
    {
        public int EmpId { get; set; }
        public int CustId { get; set; }
        public int ShipperId { get; set; }
        public int ProductId { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAdress { get; set; }
        public string? ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string? ShipCountry { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
    }
}

namespace Codifico.SalesDatePrediction.Domain.Entities
{
    public class OrdersEntity
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        public int CustId { get; set; }
        public int EmpId { get; set; }
        public int ShipperId { get; set; }
        public ICollection<CustomerEntity> Customers { get; set; }
        public ICollection<EmployeesEntity> Employees { get; set; }
        public ICollection<ShippersEntity> Shippers { get; set; }

    }
}

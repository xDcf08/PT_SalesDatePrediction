namespace Codifico.SalesDatePrediction.Domain.Entities
{
    public class OrderDetailsEntity
    {
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
        public int ProductId { get; set; }
        public ICollection<ProductsEntity> Products { get; set; }
    }
}

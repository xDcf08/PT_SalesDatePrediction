using System.ComponentModel.DataAnnotations.Schema;

namespace Codifico.SalesDatePrediction.Domain.Entities
{
    public class ProductsEntity
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public ICollection<SuppliersEntity> Suppliers { get; set; }
        public ICollection<CategoriesEntity> Categories { get; set; }
        public OrderDetailsEntity OrderDetail { get; set; }
    }
}

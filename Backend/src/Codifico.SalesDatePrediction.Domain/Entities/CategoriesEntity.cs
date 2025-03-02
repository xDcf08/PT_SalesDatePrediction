namespace Codifico.SalesDatePrediction.Domain.Entities
{
    public class CategoriesEntity
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public ProductsEntity Products { get; set; }
    }
}

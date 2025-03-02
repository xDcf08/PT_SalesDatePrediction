namespace Codifico.SalesDatePrediction.Application.DataBase.Products.Queries.GetAllProducts
{
    public interface IGetAllProductsQuery
    {
        Task<List<GetAllProductsDTO>> ExecuteAsync();
    }
}

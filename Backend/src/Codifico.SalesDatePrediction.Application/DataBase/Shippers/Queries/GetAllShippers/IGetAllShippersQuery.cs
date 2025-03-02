namespace Codifico.SalesDatePrediction.Application.DataBase.Shippers.Queries.GetAllShippers
{
    public interface IGetAllShippersQuery
    {
        Task<List<GetAllShippersDTO>> ExecuteAsync();
    }
}

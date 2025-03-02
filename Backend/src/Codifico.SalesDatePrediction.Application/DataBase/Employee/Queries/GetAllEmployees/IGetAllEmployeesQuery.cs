namespace Codifico.SalesDatePrediction.Application.DataBase.Employee.Queries.GetAllEmployees
{
    public interface IGetAllEmployeesQuery
    {
        Task<List<GetAllEmployeesDTO>> ExecuteAsync();
    }
}

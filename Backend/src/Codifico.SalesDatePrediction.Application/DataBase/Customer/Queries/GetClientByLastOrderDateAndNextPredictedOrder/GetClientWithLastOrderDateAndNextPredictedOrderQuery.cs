using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Codifico.SalesDatePrediction.Application.DataBase.Customer.Queries.GetClientByLastOrderDateAndNextPredictedOrder
{
    public class GetClientWithLastOrderDateAndNextPredictedOrderQuery : IGetClientWithLastOrderDateAndNextPredictedOrderQuery
    {
        private readonly IApplicationDbContext _context;
        public GetClientWithLastOrderDateAndNextPredictedOrderQuery(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetClientWithLastOrderDateAndNextPredictedOrderDTO>> ExecuteAsync()
        {
            var Sql = $@"WITH Diferencias AS (
	                        SELECT 
                                sc.custid AS custId,
		                        sc.companyname AS CustomerName,
		                        so.orderdate,
		                        LAG(so.orderdate) OVER (PARTITION BY sc.companyname ORDER BY so.orderdate) AS fecha_anterior,
		                        DATEDIFF(DAY, LAG(so.orderdate) OVER (PARTITION BY sc.companyname ORDER BY so.orderdate), so.orderdate) AS diferencia
	                        FROM Sales.Orders so
	                        INNER JOIN Sales.Customers sc ON so.custid = sc.custid
                        )

                        select 
                        custId,
                        CustomerName,
                        utlima_fecha AS LastOrderDate,
                        FORMAT(DATEADD(DAY, Promedio_Dias, utlima_fecha), 'dd/MM/yyyy', 'es-ES') AS NextPredictedOrder from (
                        SELECT 
                            custId,
	                        CustomerName,
	                        AVG(diferencia) AS Promedio_Dias,
	                        MAX(orderdate) AS utlima_fecha
                        FROM Diferencias
                        GROUP BY custId, CustomerName
                        ) datos
                        ";

            var result = await _context.Database.SqlQueryRaw<GetClientWithLastOrderDateAndNextPredictedOrderDTO>(Sql).ToListAsync();

            return result;
        }
    }
}

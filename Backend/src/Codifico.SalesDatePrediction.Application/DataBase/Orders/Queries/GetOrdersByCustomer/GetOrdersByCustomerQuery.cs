using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Codifico.SalesDatePrediction.Application.DataBase.Orders.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQuery : IGetOrdersByCustomerQuery
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetOrdersByCustomerQuery(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetOrdersByCustomerDTO>> ExecuteAsync(int custId)
        {
            var exist = await _context.Customers.FindAsync(custId);

            if (exist == null)
                throw new Exception("El cliente consultado no existe");

            var result = await _context.Orders
                .Where(x => x.CustId == exist.CustId)
                .OrderByDescending(x => x.OrderDate)
                .ToListAsync();

            return _mapper.Map<List<GetOrdersByCustomerDTO>>(result);
        }
    }
}

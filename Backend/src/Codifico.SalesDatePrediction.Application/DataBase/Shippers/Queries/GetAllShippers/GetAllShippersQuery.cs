using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Codifico.SalesDatePrediction.Application.DataBase.Shippers.Queries.GetAllShippers
{
    public class GetAllShippersQuery : IGetAllShippersQuery
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllShippersQuery(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllShippersDTO>> ExecuteAsync()
        {
            var shippers = await _context.Shipper.ToListAsync();

            return _mapper.Map<List<GetAllShippersDTO>>(shippers);
        }
    }
}

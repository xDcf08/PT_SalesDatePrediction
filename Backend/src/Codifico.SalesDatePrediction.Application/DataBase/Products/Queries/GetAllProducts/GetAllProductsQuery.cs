using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Codifico.SalesDatePrediction.Application.DataBase.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IGetAllProductsQuery
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQuery(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductsDTO>> ExecuteAsync()
        {
            var products = await _context.Product.ToListAsync();

            return _mapper.Map<List<GetAllProductsDTO>>(products);
        }
    }
}

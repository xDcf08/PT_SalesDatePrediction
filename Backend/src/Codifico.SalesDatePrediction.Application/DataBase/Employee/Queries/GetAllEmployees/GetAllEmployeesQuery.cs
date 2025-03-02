using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Codifico.SalesDatePrediction.Application.DataBase.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IGetAllEmployeesQuery
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllEmployeesQuery(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllEmployeesDTO>> ExecuteAsync()
        {
            var employees = await _context.Employees.ToListAsync();

            return _mapper.Map<List<GetAllEmployeesDTO>>(employees);
        }
    }
}

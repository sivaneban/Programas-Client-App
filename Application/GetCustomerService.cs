using System.Collections.Generic;
using MediatR;
using Domain;
using DataContext;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Application
{
    public class GetCustomerService
    {
        public class Query : IRequest<List<Customer>>
        { }

        public class Handler : IRequestHandler<Query, List<Customer>>
        {
            private readonly CustomerContext _context;
            public Handler(CustomerContext context)
            {
                _context = context;
            }

            public async Task<List<Customer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var customers = await _context.Customers.Include(c=>c.CustomerAddress).AsNoTracking().ToListAsync();
                return customers;
            }
        }
    }
}

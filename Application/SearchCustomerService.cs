using System.Collections.Generic;
using MediatR;
using Domain;
using DataContext;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq;

namespace Application
{
    public class SearchCustomerService
    {
        public class Query : IRequest<List<Customer>>
        {
            public string SearchTerm { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Customer>>
        {
            private readonly CustomerContext _context;
            public Handler(CustomerContext context)
            {
                _context = context;
            }

            public async Task<List<Customer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var customers = await _context.Customers.ToListAsync();
                var searchedCustomers = await _context.Customers.Where(c => c.Username.StartsWith(request.SearchTerm) || c.Email.StartsWith(request.SearchTerm)).Include(c => c.CustomerAddress).AsNoTracking().ToListAsync();
                return searchedCustomers;
            }
        }
    }
}

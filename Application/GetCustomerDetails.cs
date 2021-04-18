using System.Collections.Generic;
using MediatR;
using Domain;
using DataContext;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System;

namespace Application
{
    public class GetCustomerDetails
    {
        public class Query : IRequest<Customer>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Customer>
        {
            private readonly CustomerContext _context;
            public Handler(CustomerContext context)
            {
                _context = context;
            }

            public async Task<Customer> Handle(Query request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.FindAsync(request.Id);
                return customer;
            }
        }
    }
}

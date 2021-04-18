using System;
using Domain;
using DataContext;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Application
{
    public class CreateCustomerService
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }

            public Address CustomerAddress { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly CustomerContext _context;
            public Handler(CustomerContext context)
            {
                _context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var customer = new Customer
                {
                    Id = request.Id,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Mobile = request.Mobile,
                    Email = request.Email,
                    Username = request.Username,
                    CustomerAddress =request.CustomerAddress
                };
                _context.Customers.Add(customer);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}

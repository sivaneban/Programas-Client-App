using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using Application;
using Domain;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> List()
        {
            return await _mediator.Send(new GetCustomerService.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Details(Guid id)
        {
            return await _mediator.Send(new GetCustomerDetails.Query {Id=id });
        }

        [HttpGet("search/{term}")]
        public async Task<ActionResult<List<Customer>>> Search(string term)
        {
            return await _mediator.Send(new SearchCustomerService.Query {SearchTerm = term });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateCustomerService.Command command)
        {
            return await _mediator.Send(command);
        }

    }
}

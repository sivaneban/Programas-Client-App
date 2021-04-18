using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain;
using Application;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
        }

        [HttpGet("search/{searchterm}")]
        public Task<string> Get(string searchterm)
        {
            return AddressService.getAddressList(searchterm);
        }

        [HttpGet("selected/{fulladdress}")]
        public Task<Address> GetFinalAddress(string fulladdress)
        {
            return AddressService.getAddress(fulladdress);
        }
    }
}

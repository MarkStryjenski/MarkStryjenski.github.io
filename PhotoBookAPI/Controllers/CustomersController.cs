using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoBookAPI.Models;
using PhotoBookAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return await _customerRepository.Get(id);
        }
    }
}

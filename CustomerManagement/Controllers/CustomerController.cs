using CustomerManagement.Models;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers= await _customerService.GetAll();
            return Ok(customers);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            var addedCsustomer = await _customerService.CreateCustomer(customer);
            return Ok(addedCsustomer);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var updatedCsustomer = await _customerService.UpdateCustomer(customer);
            return Ok(updatedCsustomer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}

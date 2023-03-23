using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using DigitalBank.Infrastructure.Contracts.Business;
using DigitalBank.Infrastructure.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerBusiness _business;
        public CustomersController(ICustomerBusiness customerBusiness)
        {
            _business = customerBusiness;
        }

        // GET: api/<DigitalBankController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var customers = await _business.GetCustomers();
            return Ok(customers);
        }

        // GET api/<DigitalBankController>/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Log.Debug($"Trying to get the Customer data having Id as:{id}");
            var customer = await _business.GetCustomerById(id);
            if (customer is null)
            {
                Log.Information($"There is no Customer having Id as:{id}");
                return NotFound($"There is no Customer having Id as:{id}");
            }
            return Ok(customer);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> Get(string name)
        {
            Log.Debug($"Trying to get the Customer data having Name as:{name}");
            var customer = await _business.GetCustomerByName(name);
            if (customer is null)
            {
                Log.Information($"There is no Customer having Name as:{name}");
                return NotFound($"There is no Customer having Name as:{name}");
            }
            return Ok(customer);
        }

        // POST api/<DigitalBankController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerModel customerModel)
        {
            if (customerModel == null)
            {
                return BadRequest();
            }
            try
            {
                Log.Debug($"Trying to add a new Customer");
                var customer = await _business.AddCustomer(customerModel);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("account")]
        public async Task<ActionResult> PostAccount(BaseAccountModel accountModel)
        {
            if (accountModel is null)
            {
                return BadRequest();
            }
            try
            {
                Log.Debug($"Trying to add a new Account of a Customer having Id as:{accountModel.CustomerId}");
                var account = await _business.AddAccount(accountModel);
                return Ok(account);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DigitalBankController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BaseCustomerModel customerModel)
        {
            try
            {
                Log.Debug($"Trying to get the Customer data having Id as:{id}");
                var customer = await _business.GetCustomerById(id);
                if (customer is null)
                {
                    Log.Information($"There is no Customer having Id as:{id}");
                    return NotFound($"There is no Customer having Id as:{id}");
                }
                var updateCustomer = await _business.UpdateCustomer(id, customerModel);
                return Ok(updateCustomer);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest();
            }
        }

        // DELETE api/<DigitalBankController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Log.Debug($"Trying to get the Customer data having Id as:{id}");
                var customer = await _business.GetCustomerById(id);
                if (customer is null)
                {
                    Log.Information($"There is no Customer having Id as:{id}");
                    return NotFound($"There is no Customer having Id as:{id}");
                }
                await _business.DeleteCustomer(customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest();
            }
        }
    }
}

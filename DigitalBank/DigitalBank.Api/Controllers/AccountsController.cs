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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountBusiness _business;
        public AccountsController(IAccountBusiness accountBusiness)
        {
            this._business = accountBusiness;
        }

        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountModel>>> Get()
        {
            var accounts = await _business.GetAccounts();
            return Ok(accounts);
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Log.Debug($"Trying to get the Account data having Id as:{id}");
            var account = await _business.GetAccountById(id);
            if (account is null)
            {
                Log.Information($"There is no Account data having Id as:{id}");
                return NotFound($"There is no Account data having Id as:{id}");
            }
            return Ok(account);
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Log.Debug($"Trying to get the Account data having Id as:{id}");
                var account = await _business.GetAccountById(id);
                if (account is null)
                {
                    Log.Information($"There is no Account data having Id as:{id}");
                    return NotFound($"There is no Account data having Id as:{id}");
                }
                await _business.DeleteAccount(account);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest();
            }
        }
    }
}

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
    public class BanksController : ControllerBase
    {
        private readonly IBankBusiness _business;
        public BanksController(IBankBusiness business)
        {
            this._business = business;
        }

        // GET: api/<Banks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseBankModel>>> Get()
        {
            var banks = await _business.GetBanks();
            return Ok(banks);
        }

        // GET api/<Banks>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseBankModel>> Get(int id)
        {
            Log.Debug($"Trying to get the Bank data having Id as:{id}");
            var bank = await _business.GetBankById(id);
            if (bank is null)
            {
                Log.Information($"There is no Bank having Id as:{id}");
                return NotFound($"There is no Bank having Id as:{id}");
            }
            return Ok(bank);
        }

        // POST api/<Banks>
        [HttpPost]
        public async Task<ActionResult<BankModel>> Post([FromBody] BankModel bankModel)
        {
            if (bankModel is null)
            {
                return BadRequest();
            }
            try
            {
                Log.Debug($"Trying to add the Bank");
                var bank = await _business.AddBank(bankModel);
                return Ok(bank);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Banks>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BaseBankModel bankModel)
        {
            try
            {
                Log.Debug($"Trying to get the Bank data having Id as:{id}");
                var bank = await _business.GetBankById(id);
                if (bank is null)
                {
                    Log.Information($"There is no Bank having Id as:{id}");
                    return NotFound();
                }
                var updateBank = await _business.UpdateBank(id, bankModel);
                return Ok(updateBank);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest();
            }
        }

        // DELETE api/<Banks>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Log.Debug($"Trying to get the Bank data having Id as:{id}");
                var bank = await _business.GetBankById(id);
                if (bank is null)
                {
                    Log.Information($"There is no Bank having Id as:{id}");
                    return NotFound();
                }
                await _business.DeleteBank(bank);
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

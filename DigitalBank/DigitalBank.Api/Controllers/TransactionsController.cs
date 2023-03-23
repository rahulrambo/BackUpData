using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using DigitalBank.Infrastructure.Contracts.Business;
using DigitalBank.Infrastructure.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionBusiness _business;
        public TransactionsController(ITransactionBusiness business)
        {
            _business = business;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var transactions = await _business.GetTransactions();
            return Ok(transactions);
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Log.Debug($"Trying to get the transaction data having Id as:{id}");
            var transaction = await _business.GetTransactionById(id);
            if (transaction == null)
            {
                Log.Information($"There is no transaction data having Id as:{id}");
                return NotFound($"There is no transaction data having Id as:{id}");
            }
            return Ok(transaction);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BaseTransactionModel transactionModel)
        {
            if (transactionModel == null)
            {
                return BadRequest();
            }
            try
            {
                Log.Debug($"Trying to add the transaction");
                var transaction = await _business.AddTranscation(transactionModel);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BaseTransactionModel transactionModel)
        {
            try
            {
                Log.Debug($"Trying to get the transaction data having Id as:{id}");
                var transaction = await _business.GetTransactionById(id);
                if (transaction is null)
                {
                    Log.Information($"There is no transaction data having Id as:{id}");
                    return NotFound($"There is no transaction data having Id as:{id}");
                }
                var updateTransaction = await _business.UpdateTransaction(id, transactionModel);
                return Ok(updateTransaction);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong and the error is: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Log.Debug($"Trying to get the transaction data having Id as:{id}");
                var transaction = await _business.GetTransactionById(id);
                if (transaction is null)
                {
                    Log.Information($"There is no transaction data having Id as:{id}");
                    return NotFound($"There is no transaction data having Id as:{id}");
                }
                await _business.DeleteTransaction(transaction);
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

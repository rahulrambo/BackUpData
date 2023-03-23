using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using DigitalBank.Infrastructure.Contracts.Repository;
using DigitalBank.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Repository.Repository
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly DigitalBankContext context;
        public TransactionRepository(DigitalBankContext digitalBankContext)
        {
            context = digitalBankContext;
        }
        public async Task<IEnumerable<TransactionModel>> GetTransactions()
        {
            return context.Transactions.Select(t => new TransactionModel { Id = t.Id, Name = t.Account.Customer.FirstName, TransactionType = t.TransactionType, Amount = t.Amount });
        }
        public async Task<TransactionModel> GetTransactionModel(int transactionId)
        {
            var transaction=await context.Transactions.Include(t=>t.Account).ThenInclude(c=>c.Customer).FirstOrDefaultAsync(t => t.Id == transactionId);
            if(transaction != null)
            {
                return new TransactionModel { Id = transaction.Id,Name=transaction.Account.Customer.FirstName, TransactionType = transaction.TransactionType, Amount = transaction.Amount };
            }
            return null;
        }
        public async Task<Transaction> GetTransactionById(int transactionId)
        {
            return await context.Transactions.FirstOrDefaultAsync(t => t.Id == transactionId);
        }
        public async Task<Transaction> AddTranscation(Transaction transaction)
        {            
            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();            
            return transaction;
        }
        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {            
            await context.SaveChangesAsync();
            return transaction;
        }
        public async Task DeleteTransaction(Transaction transaction)
        {
            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();
        }
    }
}

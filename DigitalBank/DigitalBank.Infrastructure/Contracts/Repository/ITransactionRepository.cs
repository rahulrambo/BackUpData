using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DigitalBank.Infrastructure.Contracts.Repository
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<TransactionModel>> GetTransactions();
        public Task<TransactionModel> GetTransactionModel(int transactionId);
        public Task<Entities.Entities.Transaction> GetTransactionById(int transactionId);
        public Task<Entities.Entities.Transaction> AddTranscation(Entities.Entities.Transaction transaction);
        public Task<Entities.Entities.Transaction> UpdateTransaction(Entities.Entities.Transaction transaction);
        public Task DeleteTransaction(Entities.Entities.Transaction transaction);
    }
}

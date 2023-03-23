using DigitalBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Infrastructure.Contracts.Business
{
    public interface ITransactionBusiness
    {
        public Task<IEnumerable<TransactionModel>> GetTransactions();
        public Task<TransactionModel> GetTransactionModel(int transactionId);
        public Task<Entities.Entities.Transaction> GetTransactionById(int transactionId);
        public Task<BaseTransactionModel> AddTranscation(BaseTransactionModel transaction);
        public Task<BaseTransactionModel> UpdateTransaction(int id, BaseTransactionModel transaction);
        public Task DeleteTransaction(Entities.Entities.Transaction transaction);
    }
}

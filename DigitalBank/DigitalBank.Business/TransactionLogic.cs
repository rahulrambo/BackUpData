using DigitalBank.Business.Models;
using DigitalBank.Core.Custom_Exception;
using DigitalBank.Entities.Entities;
using DigitalBank.Infrastructure.Contracts.Business;
using DigitalBank.Infrastructure.Contracts.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Business
{
    public class TransactionLogic : ITransactionBusiness
    {
        private readonly ITransactionRepository _transaction;
        private readonly IAccountRepository _account;
        public TransactionLogic(ITransactionRepository transaction, IAccountRepository accountRepository)
        {
            _transaction = transaction;
            _account = accountRepository;
        }
        public async Task<IEnumerable<TransactionModel>> GetTransactions()
        {
            return await _transaction.GetTransactions();
        }

        public async Task<TransactionModel> GetTransactionModel(int transactionId)
        {
            return await _transaction.GetTransactionModel(transactionId);
        }

        public async Task<Transaction> GetTransactionById(int transactionId)
        {
            return await _transaction.GetTransactionById(transactionId);
        }

        public async Task<BaseTransactionModel> AddTranscation(BaseTransactionModel transaction)
        {
            Log.Debug($"Trying to get the Account data having id as:{transaction.AccountId}");
            Account account = await _account.GetAccountById(transaction.AccountId);
            if (account is null)
            {
                Log.Information($"There is no such type of account having Id as:{transaction.AccountId} Please enter a valid Account Id!");
                throw new AccountNotFoundException(transaction.AccountId);
            }
            Transaction transactionToCreate = new Transaction
            {
                AccountId = transaction.AccountId,
                TransactionType = transaction.TransactionType,
                Amount = transaction.Amount,
                TransactionTime = DateTime.Now,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            await _transaction.AddTranscation(transactionToCreate);
            return transaction;
        }

        public async Task<BaseTransactionModel> UpdateTransaction(int id, BaseTransactionModel transactionModel)
        {
            var transaction = await _transaction.GetTransactionById(id);
            transaction.AccountId = transactionModel.AccountId;
            transaction.TransactionType = transactionModel.TransactionType;
            transaction.Amount = transactionModel.Amount;
            transaction.TransactionTime = DateTime.Now;
            transaction.UpdatedDate = DateTime.Now;
            await _transaction.UpdateTransaction(transaction);
            return transactionModel;
        }

        public async Task DeleteTransaction(Transaction transaction)
        {
            await _transaction.DeleteTransaction(transaction);
        }
    }
}

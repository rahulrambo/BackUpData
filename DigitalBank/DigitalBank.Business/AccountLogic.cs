using DigitalBank.Business.Models;
using DigitalBank.Core.Custom_Exception;
using DigitalBank.Entities.Entities;
using DigitalBank.Infrastructure.Contracts.Business;
using DigitalBank.Infrastructure.Contracts.Repository;
using DigitalBank.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Business
{
    public class AccountLogic : IAccountBusiness
    {
        private readonly IAccountRepository _repository;
        public AccountLogic(IAccountRepository repository)
        {
            _repository=repository;
        }
        public async Task<IEnumerable<AccountModel>> GetAccounts()
        {
            return await _repository.GetAccounts();
        }
        public async Task<AccountModel> GetAccountModel(int id)
        {
            return await _repository.GetAccountModel(id);
        }       
        public async Task<Account> GetAccountById(int id)
        {
            return await _repository.GetAccountById(id);
        }       
        public async Task DeleteAccount(Account account)
        {            
            await _repository.DeleteAccount(account);
        }
    }
}

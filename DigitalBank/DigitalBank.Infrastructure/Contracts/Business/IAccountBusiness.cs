using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Infrastructure.Contracts.Business
{
    public interface IAccountBusiness
    {
        public Task<IEnumerable<AccountModel>> GetAccounts();
        public Task<AccountModel> GetAccountModel(int id);        
        public Task<Account> GetAccountById(int id);        
        public Task DeleteAccount(Account account);
    }
}

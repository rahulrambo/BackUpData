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
    public class AccountRepository : IAccountRepository
    {
        private readonly DigitalBankContext context;
        public AccountRepository(DigitalBankContext digitalBankContext)
        {
            context = digitalBankContext;
        }
        public async Task<IEnumerable<AccountModel>> GetAccounts()
        {
            return context.Accounts.Select(a => new AccountModel { CustomerName = a.Customer.FirstName, BankName = a.Bank.Name, BranchCode = a.Branch.Code, AccountType = a.AccountType, IsActive = a.IsActive, Balance = a.Balance });
        }
        public async Task<AccountModel> GetAccountModel(int id)
        {
            var s = from Customer c in context.Customers
                    join Account a in context.Accounts on c.Id equals a.CustomerId
                    join Bank b in context.Banks on a.BankId equals b.Id
                    join BankBranch br in context.BankBranches on a.BranchId equals br.Id
                    where a.Id == id
                    select new AccountModel
                    {                        
                        CustomerName = c.FirstName,
                        BankName = b.Name,
                        BranchCode = br.Code,
                        AccountType = a.AccountType,
                        IsActive = a.IsActive,
                        Balance = a.Balance
                    };
            return await s.FirstOrDefaultAsync();
        }
        public async Task<Account> GetAccountById(int id)
        {
            return await context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }               
        public async Task DeleteAccount(Account account)
        {
            account.IsActive= false;            
            await context.SaveChangesAsync();
        }
    }
}

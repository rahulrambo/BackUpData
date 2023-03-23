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
    public class BankRepository:IBankRepository
    {
        private readonly DigitalBankContext context;
        public BankRepository(DigitalBankContext digitalBankContext)
        {
            context = digitalBankContext;
        }
        public async Task<IEnumerable<BaseBankModel>> GetBanks()
        {
            return context.Banks.Select(b => new BaseBankModel { Id = b.Id, Name = b.Name, Code = b.Code });
        }
        public async Task<BaseBankModel> GetBankModel(int id)
        {
            var bank = await context.Banks.FirstOrDefaultAsync(b => b.Id == id);        
            if(bank != null)
            {
                return new BaseBankModel { Id = bank.Id, Name = bank.Name, Code = bank.Code };
            }
            return null;
        }
        public async Task<Bank> GetBankById(int id)
        {
            return await context.Banks.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<Bank> GetBankByName(string name,string code)
        {
            var bank= await context.Banks.FirstOrDefaultAsync(b => b.Name==name || b.Code==code);            
            return bank;
        }           
        public async Task<Bank> AddBank(Bank bank)
        {           
            await context.Banks.AddAsync(bank);
            await context.SaveChangesAsync();
            return bank;
        }
        public async Task<BaseBankModel> UpdateBank(Bank bank)
        {            
            await context.SaveChangesAsync();            
            return new BaseBankModel { Id = bank.Id, Name = bank.Name, Code = bank.Code };
        }
        public async Task DeleteBank(Bank bank)
        {
            var bankId = bank.Id;
            Bank getBank = await context.Banks.FirstOrDefaultAsync(t => t.Id == bankId);
            var accounts =context.Accounts.Where(a => a.BankId == bankId).ToList();
            var branches = context.BankBranches.Where(br => br.BankId == bankId).ToList();
            //Bank getBank = await context.Banks.FirstOrDefaultAsync(t => t.Id == bankId);
            //var accounts =context.Accounts.ToList().Where(a => a.BankId == bankId);
            //var branches = context.BankBranches.ToList().Where(br => br.BankId == bankId);
            var transactions = from a in context.Accounts
                               join t in context.Transactions on a.Id equals t.AccountId
                               select t;
            context.Transactions.RemoveRange(transactions);
            context.Accounts.RemoveRange(accounts);
            context.BankBranches.RemoveRange(branches);
            context.Banks.Remove(getBank);
            await context.SaveChangesAsync();
        }
    }
}

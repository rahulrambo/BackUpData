using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Infrastructure.Contracts.Repository
{
    public interface IBankRepository
    {
        public Task<IEnumerable<BaseBankModel>> GetBanks();
        public Task<BaseBankModel> GetBankModel(int id);
        public Task<Bank> GetBankById(int id);
        public Task<Bank> GetBankByName(string name,string code);
        public Task<BaseBankModel> UpdateBank(Bank bank);        
        public Task<Bank> AddBank(Bank bank);
        public Task DeleteBank(Bank bank);
    }
}

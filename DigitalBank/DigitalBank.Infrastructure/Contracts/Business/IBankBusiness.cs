using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Infrastructure.Contracts.Business
{
    public interface IBankBusiness
    {
        public Task<IEnumerable<BaseBankModel>> GetBanks();
        public Task<BaseBankModel> GetBankModel(int id);
        public Task<Bank> GetBankById(int id);
        public Task<BaseBankModel> UpdateBank(int id, BaseBankModel bank);        
        public Task<BankModel> AddBank(BankModel bankModel);
        public Task DeleteBank(Bank bank);
    }
}

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
    public class BankLogic : IBankBusiness
    {
        private readonly IBankRepository _bankRepository;
        private readonly ICustomerRepository _customerRepository;
        public BankLogic(IBankRepository bankRepository, ICustomerRepository customerRepository)
        {
            _bankRepository = bankRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<BaseBankModel>> GetBanks()
        {
            return await _bankRepository.GetBanks();
        }
        public async Task<BaseBankModel> GetBankModel(int id)
        {
            return await _bankRepository.GetBankModel(id);
        }
        public async Task<Bank> GetBankById(int id)
        {
            return await _bankRepository.GetBankById(id);
        }
        public async Task<BaseBankModel> UpdateBank(int id, BaseBankModel bankModel)
        {
            var bank = await _bankRepository.GetBankById(id);
            bank.Id = bankModel.Id;
            bank.Name = bankModel.Name;
            bank.Code = bankModel.Code;
            bank.UpdatedDate = DateTime.Now;
            await _bankRepository.UpdateBank(bank);
            return bankModel;
        }
        public async Task<BankModel> AddBank(BankModel bankModel)
        {
            Log.Debug($"Checking for the Bank having Name as{bankModel.Name} Code as:{bankModel.Code}!");
            Bank bank = await _bankRepository.GetBankByName(bankModel.Name, bankModel.Code);
            Log.Debug($"Checking for the Branch having Code as:{bankModel.BranchCode}!");
            var branch = await _customerRepository.GetBranchByCode(bankModel.BranchCode);
            if (branch != null)
            {
                Log.Information($"There is already Branch having Code as:{bankModel.BranchCode}!");
                throw new BranchExistException(bankModel.BranchCode);
            }
            if (bank != null)
            {
                Log.Information($"There is already Bank having Name as:{bankModel.Name} or Code as:{bankModel.Code}!");
                throw new BankExistException(bankModel.Name, bankModel.Code);
            }
            BankBranch bankBranch = new BankBranch()
            {
                Code = bankModel.BranchCode,
                Address1 = bankModel.Address,
                City = bankModel.City,
                District = bankModel.District,
                State = bankModel.State,
                ZipCode = bankModel.ZipCode,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            Bank bankToCreate = new Bank()
            {
                BankBranches = new List<BankBranch> { bankBranch },
                Name = bankModel.Name,
                Code = bankModel.Code,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            await _bankRepository.AddBank(bankToCreate);
            return bankModel;
        }
        public async Task DeleteBank(Bank bank)
        {
            await _bankRepository.DeleteBank(bank);
        }
    }
}

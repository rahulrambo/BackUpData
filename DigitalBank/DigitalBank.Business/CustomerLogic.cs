using DigitalBank.Business.Models;
using DigitalBank.Core.Custom_Exception;
using DigitalBank.Core.Enum;
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
    public class CustomerLogic : ICustomerBusiness
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBankRepository _bankRepository;
        public CustomerLogic(ICustomerRepository customerRepository, IBankRepository bankRepository)
        {
            _customerRepository = customerRepository;
            _bankRepository = bankRepository;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerRepository.GetCustomerById(id);
        }
        public async Task<CustomerModel> GetCustomerModel(int id)
        {
            return await _customerRepository.GetCustomerModel(id);
        }
        public async Task<CustomerModel> GetCustomerByName(string firstName)
        {
            return await _customerRepository.GetCustomerByName(firstName);
        }
        public async Task<CustomerModel> AddCustomer(CustomerModel customerModel)
        {
            Log.Debug($"Trying to get the Bank data having Id as:{customerModel.BankId} and BranchCode having Code as:{customerModel.BranchCode}");
            Bank bank = await _bankRepository.GetBankById(customerModel.BankId);
            BankBranch branch = await _customerRepository.GetBranchByCode(customerModel.BranchCode);
            if (branch is null)
            {
                Log.Information($"There is no Branch having Code as:{customerModel.BranchCode}");
                throw new BranchNotFoundException(customerModel.BranchCode);
            }
            else
            {
                Customer customerToCreate = new Customer
                {
                    FirstName = customerModel.FirstName,
                    LastName = customerModel.Lastname,
                    Address1 = customerModel.Address,
                    City = customerModel.City,
                    District = customerModel.District,
                    State = customerModel.State,
                    ZipCode = customerModel.ZipCode,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };

                Transaction transaction = new Transaction
                {
                    TransactionTime = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    TransactionType = TransactionType.Deposit.ToString(),
                    Amount = customerModel.Amount
                };

                Account account = new Account
                {
                    Transactions = new List<Transaction> { transaction },
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    AccountType = AccountType.Salary.ToString(),
                    IsActive = true,
                    Balance = customerModel.Amount,
                    BankId = customerModel.BankId,
                    BranchId = branch.Id,
                    Customer = customerToCreate
                };

                transaction.Account = account;
                customerToCreate.Accounts = new List<Account>() { account };
                await _customerRepository.AddCustomer(customerToCreate);

            }
            return customerModel;
        }
        public async Task<BaseCustomerModel> UpdateCustomer(int id, BaseCustomerModel baseCustomerModel)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            customer.FirstName = baseCustomerModel.FirstName;
            customer.LastName = baseCustomerModel.Lastname;
            customer.Address1 = baseCustomerModel.Address;
            customer.City = baseCustomerModel.City;
            customer.District = baseCustomerModel.District;
            customer.State = baseCustomerModel.State;
            customer.ZipCode = baseCustomerModel.ZipCode;
            customer.UpdatedDate = DateTime.Now;
            await _customerRepository.UpdateCustomer(customer);
            return baseCustomerModel;
        }
        public async Task<BaseAccountModel> AddAccount(BaseAccountModel accountModel)
        {
            var customer = await _customerRepository.GetCustomerById(accountModel.CustomerId);
            var bank = await _bankRepository.GetBankById(accountModel.BankId);
            Log.Debug($"Trying to get the Customer detail having Id as:{accountModel.CustomerId} , Bank detail having Id as:{accountModel.BankId} and Branch Detail having Id as:{accountModel.BranchId}");
            var bankBranch = await _customerRepository.GetBankBranchById(accountModel.BranchId);
            if (customer is null)
            {
                Log.Information($"There is no Customer having Id as:{accountModel.CustomerId}");
                throw new CustomerNotFoundException(accountModel.CustomerId);
            }
            if (bank is null)
            {
                Log.Information($"There is no Bank having Id as:{accountModel.BankId}");
                throw new BankNotFoundException(accountModel.BankId);
            }
            if (bankBranch is null)
            {
                Log.Information($"There is no Branch having Id as:{accountModel.BranchId}");
                throw new BranchNotFoundException(accountModel.BranchId);
            }
            Account account = new Account
            {
                CustomerId = accountModel.CustomerId,
                BankId = accountModel.BankId,
                BranchId = accountModel.BranchId,
                AccountType = accountModel.AccountType,
                IsActive = true,
                Balance = accountModel.Balance,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            await _customerRepository.AddAccount(account);
            return accountModel;
        }
        public async Task DeleteCustomer(Customer customer)
        {
            await _customerRepository.DeleteCustomer(customer);
        }
    }
}

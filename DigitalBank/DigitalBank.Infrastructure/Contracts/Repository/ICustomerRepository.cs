using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Infrastructure.Contracts.Repository
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<CustomerModel>> GetCustomers();
        public Task<Customer> GetCustomerById(int id);
        public Task<CustomerModel> GetCustomerModel(int id);
        public Task<CustomerModel> GetCustomerByName(string firstName);
        public Task<Customer> AddCustomer(Customer customer);
        public Task<Customer> UpdateCustomer(Customer customer);
        public Task DeleteCustomer(Customer customer);
        public Task<BankBranch> GetBankBranchById(int branchId);
        public Task<BankBranch> GetBranchByCode(string code);
        public Task<Account> AddAccount(Account account);
    }
}

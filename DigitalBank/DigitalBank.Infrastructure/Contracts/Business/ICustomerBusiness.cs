using DigitalBank.Business.Models;
using DigitalBank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Infrastructure.Contracts.Business
{
    public interface ICustomerBusiness
    {
        public Task<IEnumerable<CustomerModel>> GetCustomers();
        public Task<Customer> GetCustomerById(int id);
        public Task<CustomerModel> GetCustomerModel(int id);
        public Task<CustomerModel> GetCustomerByName(string firstName);
        public Task<CustomerModel> AddCustomer(CustomerModel customerModel);
        public Task<BaseCustomerModel> UpdateCustomer(int id, BaseCustomerModel customerModel);
        public Task<BaseAccountModel> AddAccount(BaseAccountModel accountModel);
        public Task DeleteCustomer(Customer customer);
    }
}

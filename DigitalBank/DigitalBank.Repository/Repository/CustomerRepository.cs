using Castle.Core.Resource;
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
    public class CustomerRepository:ICustomerRepository
    {
        private readonly DigitalBankContext context;
        public CustomerRepository(DigitalBankContext digitalBankContext)
        {
            context = digitalBankContext;
        }        
        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            var customers = from Customer c in context.Customers
                    join Account a in context.Accounts on c.Id equals a.CustomerId
                    join Bank b in context.Banks on a.BankId equals b.Id
                    join BankBranch br in context.BankBranches on a.BranchId equals br.Id                    
                    select new CustomerModel
                    {
                        FirstName= c.FirstName,
                        Lastname= c.LastName,
                        Address=c.Address1,
                        City=c.City,
                        District=c.District,
                        State=c.State,
                        ZipCode=c.ZipCode,
                        BankId= b.Id,
                        BranchCode= br.Code,
                        Amount=a.Balance
                    };
            return customers;
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<CustomerModel> GetCustomerModel(int id)
        {
            var customers = from Customer c in context.Customers
                    join Account a in context.Accounts on c.Id equals a.CustomerId
                    join Bank b in context.Banks on a.BankId equals b.Id
                    join BankBranch br in context.BankBranches on a.BranchId equals br.Id
                    where c.Id == id
                    select new CustomerModel
                    {                        
                        FirstName= c.FirstName,
                        Lastname= c.LastName,
                        Address=c.Address1,
                        City=c.City,
                        District=c.District,
                        State=c.State,
                        ZipCode=c.ZipCode,
                        BankId= b.Id,
                        BranchCode= br.Code,
                        Amount=a.Balance
                    };
            return await customers.FirstOrDefaultAsync();
        }
        public async Task<CustomerModel> GetCustomerByName(string firstName)
        {
            var customers = from Customer c in context.Customers
                    join Account a in context.Accounts on c.Id equals a.CustomerId
                    join Bank b in context.Banks on a.BankId equals b.Id
                    join BankBranch br in context.BankBranches on a.BranchId equals br.Id 
                    where c.FirstName == firstName
                    select new CustomerModel
                    {                        
                        FirstName= firstName,
                        Lastname= c.LastName,
                        Address=c.Address1,
                        City=c.City,
                        District=c.District,
                        State=c.State,
                        ZipCode=c.ZipCode,
                        BankId= b.Id,
                        BranchCode= br.Code,
                        Amount=a.Balance
                    };
            return await customers.FirstOrDefaultAsync();
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {            
            await context.SaveChangesAsync();
            return customer;
        }
        public async Task DeleteCustomer(Customer customer)
        {
            context.Remove(customer);
            await context.SaveChangesAsync();
        }        
        public async Task<BankBranch> GetBranchByCode(string code)
        {
            return await context.BankBranches.FirstOrDefaultAsync(b => b.Code == code);
        }
        public async Task<BankBranch> GetBankBranchById(int branchId)
        {
            return await context.BankBranches.FirstOrDefaultAsync(b => b.Id == branchId);
        }
        public async Task<Account> AddAccount(Account account)
        {
            await context.Accounts.AddAsync(account);
            await context.SaveChangesAsync();
            return account;
        }
    }
}

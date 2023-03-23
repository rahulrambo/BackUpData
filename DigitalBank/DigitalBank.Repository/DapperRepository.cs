using Dapper;
using DigitalBank.Core;
using DigitalBank.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace DigitalBank.Repository
{
    public class DapperRepository
    {                
        public void AddBank(Bank bank)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Constants.Queries.InsertBank;
                connection.Execute(query, new
                {
                    Name = bank.Name,
                    Code = bank.Code,
                    CreatedDate = bank.CreatedDate,
                    UpdatedDate = bank.UpdatedDate
                });
            }
        }
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {                
                string query = Constants.Queries.InsertCustomer;
                connection.Execute(query, new
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address1,
                    City = customer.City,
                    District = customer.District,
                    State = customer.State,
                    ZipCode = customer.ZipCode,
                    CreatedDate = customer.CreatedDate,
                    UpdatedDate = customer.UpdatedDate
                });
            }
        }
        public Bank GetBankById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Constants.Queries.GetBank;
                var bankDetail = connection.Query<Bank>(query, new
                {
                    id = id
                });                
                return bankDetail.FirstOrDefault();
            }
        }
        public IEnumerable<CustomerBank> GetCustomerOfBank(int id)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Constants.Queries.CustomersOfABank;
                var customerDetail = connection.Query<CustomerBank>(query, new
                {
                    Id = id
                });
                return customerDetail;
            }
        }
        public CustomerBank GetCustomerAccount(int id)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Constants.Queries.CustomerAccount;
                var customerDetail = connection.Query<CustomerBank>(query, new
                {
                    Id = id
                });                
                return customerDetail.SingleOrDefault();
            }
        }
        public IEnumerable<Customer> CustomersWithNetWorth()
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Core.Constants.Queries.CustomersWithNetWorth;
                var customerDetail = connection.Query<Customer>(query);
                return customerDetail;
            }
        }
        public void BulkInsertUsingDapper(List<Bank> banks)
        {            
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {              
                connection.BulkInsert(banks);
            }
        }
    }
}

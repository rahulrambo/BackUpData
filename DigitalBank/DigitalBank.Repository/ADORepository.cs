using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using DigitalBank.Core;
using Microsoft.VisualBasic;
using DigitalBank.Entities.Entities;

namespace DigitalBank.Repository
{
    public class ADORepository
    {        
        public void AddBank(Bank bank)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Core.Constants.Queries.InsertBank;
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@Name", bank.Name);
                command.Parameters.AddWithValue("@Code", bank.Code);
                command.Parameters.AddWithValue("@CreatedDate", bank.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", bank.UpdatedDate);
                command.ExecuteNonQuery();
            }
        }
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Core.Constants.Queries.InsertCustomer;
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Address", customer.Address1);
                command.Parameters.AddWithValue("@City", customer.City);
                command.Parameters.AddWithValue("@District", customer.District);
                command.Parameters.AddWithValue("@State", customer.State);
                command.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
                command.Parameters.AddWithValue("@CreatedDate", customer.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", customer.UpdatedDate);
                command.ExecuteNonQuery();
            }
        }
        public Bank GetBankById(int bankId)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Core.Constants.Queries.GetBank;
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", bankId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var result = reader.Read();
                    if (result)
                    {
                        return new Bank { Id = Convert.ToInt32(reader[0]), Name = reader[1].ToString(), Code = reader["Code"].ToString() };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public IEnumerable<CustomerBank> GetCustomerOfBank(int bankId)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Core.Constants.Queries.CustomersOfABank;
                List<CustomerBank> listOfCustomer = new List<CustomerBank>();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", bankId);
                    adapter.Fill(dataSet);
                    var rows = dataSet.Tables[0].Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        listOfCustomer.Add(new CustomerBank { BankId = Convert.ToInt32(rows[i][0]), Name = (rows[i][1]).ToString(), FirstName = (rows[i][2]).ToString(), LastName = (rows[i][3]).ToString() });
                    }
                    return listOfCustomer;
                }
            }
        }
        public CustomerBank GetCustomerAccount(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Core.Constants.Queries.CustomerAccount;
                List<CustomerBank> accounts = new List<CustomerBank>();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", customerId);
                    adapter.Fill(dataSet);
                    var rows = dataSet.Tables[0].Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        accounts.Add(new CustomerBank { AccountId = Convert.ToInt32(rows[i][0]), CustomerId = Convert.ToInt32(rows[i][1]), FirstName = (rows[i][2]).ToString(), BankId = Convert.ToInt32(rows[i][3]), BranchId = Convert.ToInt32(rows[i][4]), AccountType = rows[i][5].ToString(), Balance = Convert.ToInt32(rows[i][6]) });
                    }
                    return accounts.SingleOrDefault();
                }
            }
        }
        public List<Customer> CustomersWithNetWorth()
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                string query = Core.Constants.Queries.CustomersWithNetWorth;
                List<Customer> customers = new List<Customer>();
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer { Id = Convert.ToInt32(reader[0]), FirstName = reader[1].ToString(), LastName = reader[2].ToString() });
                    }
                    return customers;
                }
            }
        }
        public void BulkInsertUsingAdo(DataTable dataTable)
        {
            using (SqlConnection connection = new SqlConnection(Core.Constants.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spBank", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@BankTableType";
                parameter.Value = dataTable;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
        }
    }
}

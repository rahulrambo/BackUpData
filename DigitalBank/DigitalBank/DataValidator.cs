using DigitalBank.Core;
using DigitalBank.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank
{
    public class DataValidator
    {
        Validations validations = new Validations();
        public void UserInput()
        {
            Console.WriteLine("Select your choice");
            Console.WriteLine("Enter '1' for Saving one more Bank");
            Console.WriteLine("Enter '2' for Saving one more Customer");
            Console.WriteLine("Enter '3' for Getting Bank-detail by id using DataReader");
            Console.WriteLine("Enter '4' for Getting all Customers of a bank by giving bank id using DataAdapter");
            Console.WriteLine("Enter '5' for Getting Customer and his/her accounts by giving customerId ");
            Console.WriteLine("Enter '6' for Getting top 5 net-worthy Customers");
            Console.WriteLine("Enter '7' for adding Bulk Data to the Bank Table");
            Console.WriteLine("Enter '10' for going back to startup Project");
        }
        public Bank AddBankData()
        {
            Console.Write("Enter Bank Name:");
            string name = Console.ReadLine();
            validations.ValidateName(ref name);
            Console.Write("Enter Bank Code:");
            string code = Console.ReadLine();
            validations.ValidateName(ref code);
            DateTime createdDate = DateTime.Now;
            DateTime updatedDate = DateTime.Now;
            Bank bank = new Bank()
            {
                Name = name,
                Code = code,
                CreatedDate = createdDate,
                UpdatedDate = updatedDate,
            };
            return bank;
        }
        public Customer AddCustomerData()
        {
            Console.Write("Enter FirstName of a Customer:");
            string firstName = Console.ReadLine();
            validations.ValidateName(ref firstName);
            Console.Write("Enter LastName of a Customer:");
            string lastName = Console.ReadLine();
            validations.ValidateName(ref lastName);
            Console.Write("Enter Address of a Customer:");
            string address = Console.ReadLine();
            validations.ValidateName(ref address);
            Console.Write("Enter City of a Customer:");
            string city = Console.ReadLine();
            validations.ValidateName(ref city);
            Console.Write("Enter District of a Customer:");
            string district = Console.ReadLine();
            validations.ValidateName(ref district);
            Console.Write("Enter State of a Customer:");
            string state = Console.ReadLine();
            validations.ValidateName(ref state);
            Console.Write("Enter ZipCode of a Customer:");
            string zipCode = Console.ReadLine();
            DateTime createdDate = DateTime.Now;
            DateTime updatedDate = DateTime.Now;

            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address1 = address,
                City = city,
                District = district,
                State = state,
                ZipCode = zipCode,
                CreatedDate = createdDate,
                UpdatedDate = updatedDate,
            };
            return customer;
        }
        public List<Bank> GetBanks()
        {
            List<Bank> banks = new List<Bank>(){
            new Bank() { Name = "Goa Bank", Code = "GB", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now },            
            };
            return banks;
        }      
        
        public DataTable GetBanksDataTable()
        {
            var data = GetBanks();
            return ToDataTable(data, new List<string> { nameof(Bank.Id), nameof(Bank.Accounts), nameof(Bank.BankBranches) });
        }       
        public DataTable ToDataTable<T>(IEnumerable<T> data, IEnumerable<string> ignoreColumns = null)
        {
            Type t = typeof(T);
            DataTable dt = new DataTable(t.Name);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                if (pi.CustomAttributes != null && pi.CustomAttributes.Any(x => x.AttributeType.Name == "NotMappedAttribute")) continue;
                if (
                ignoreColumns != null &&
                ignoreColumns.Any(x=>x == pi.Name)
                ) continue;
                dt.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);
            }
            if (data != null)
            {
                foreach (T item in data)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dr[dc.ColumnName] = item.GetType().GetProperty(dc.ColumnName).GetValue(item, null) ?? DBNull.Value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}

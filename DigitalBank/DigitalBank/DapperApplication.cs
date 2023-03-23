using DigitalBank.Core;
using DigitalBank.Repository;
using DigitalBank.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigitalBank
{
    public class DapperApplication
    {
        DapperRepository dapperRepository = new DapperRepository();
        DataValidator dataValidator = new DataValidator();
        public void Start(string[] args)
        {            
        option:
            Console.WriteLine("Welcome to Dapper Program!!!");
            dataValidator.UserInput();
            if (!int.TryParse(Console.ReadLine(), out int inputValue))
            {
                Console.WriteLine("Please enter a valid input");
                goto option;
            }
            bool input = true;
            while (input)
            {
                switch (inputValue)
                {
                    case 1:
                        try
                        {
                            InsertBank();
                            Console.WriteLine($"Data added successfully\n");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 2:
                        DapperApplication dapperApplication = new DapperApplication();
                        try
                        {
                            dapperApplication.InsertCustomer();
                            Console.WriteLine($"Data added successfully\n");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 3:
                        Console.Write("Enter BankId for getting the Bank Detail of particular Bank:");
                    getBankId:
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("Please enter a valid BankId");
                            goto getBankId;
                        }
                        try
                        {
                            var bankDetail = dapperRepository.GetBankById(id);
                            if (bankDetail == null)
                            {
                                Console.WriteLine($"There is no bank having Id as:{id}");
                                goto option;
                            }
                            Console.WriteLine($"{bankDetail.Id}\t{bankDetail.Name}\t{bankDetail.Code}\t{bankDetail.CreatedDate}\t{bankDetail.UpdatedDate}\n");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 4:
                        Console.Write("Enter BankId for getting all customers of a bank:");
                    bankId:
                        if (!int.TryParse(Console.ReadLine(), out int inputBankId))
                        {
                            Console.WriteLine("Please enter a valid BankId");
                            goto bankId;
                        }
                        try
                        {
                            var customerDetail = dapperRepository.GetCustomerOfBank(inputBankId);
                            if (customerDetail.Count() == 0)
                            {
                                Console.WriteLine($"There is no Bank having Id as:{inputBankId}");
                            }
                            foreach (var item in customerDetail)
                            {
                                Console.WriteLine($"{item.BankId}\t{item.Name}\t{item.FirstName}\t{item.LastName}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 5:
                        Console.Write("Enter CustomerId for getting account detail:");
                    customerId:
                        if (!int.TryParse(Console.ReadLine(), out int inputCustomerId))
                        {
                            Console.WriteLine("Please enter a valid CustomerId");
                            goto customerId;
                        }
                        try
                        {
                            var customerAccount = dapperRepository.GetCustomerAccount(inputCustomerId);
                            if (customerAccount is null)
                            {
                                Console.WriteLine($"There is no Customer having Id as:{inputCustomerId}");
                            }
                            else
                            {
                                Console.WriteLine($"{customerAccount.AccountId}\t{customerAccount.CustomerId}\t{customerAccount.FirstName}\t{customerAccount.BankId}\t{customerAccount.BranchId}\t{customerAccount.AccountType}\t{customerAccount.Balance}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 6:
                        try
                        {
                            var customers = dapperRepository.CustomersWithNetWorth();
                            foreach (var item in customers)
                            {
                                Console.WriteLine($"{item.Id}\t{item.FirstName}\t{item.LastName}\t{item.State}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 7:
                        try
                        {
                            var addBankTable = dataValidator.GetBanks();
                            dapperRepository.BulkInsertUsingDapper(addBankTable);
                            Console.WriteLine("Bulk Data added successfully");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 10:
                        input = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid Option\n");
                        goto option;
                }
            }
        }
        public void InsertBank()
        {
            var bank = dataValidator.AddBankData();
            dapperRepository.AddBank(bank);
        }
        public void InsertCustomer()
        {
            var customer = dataValidator.AddCustomerData();
            dapperRepository.AddCustomer(customer);
        }
    }
}

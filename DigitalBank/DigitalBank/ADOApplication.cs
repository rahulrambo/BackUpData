using DigitalBank.Core;
using DigitalBank.Repository;
using DigitalBank.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank
{
    public class ADOApplication
    {
        ADORepository adoRepository = new ADORepository();
        DataValidator dataValidator = new DataValidator();
        public void Start(string[] args)
        {
        option:
            Console.WriteLine("Welcome to ADO Program!!");
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
                            insertBank();
                            Console.WriteLine($"Data added successfully\n");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 2:
                        ADOApplication aDOApplication = new ADOApplication();
                        try
                        {
                            aDOApplication.InsertCustomer();
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
                            var bankDetail = adoRepository.GetBankById(id);
                            Console.WriteLine($"{bankDetail.Id}\t{bankDetail.Name}\t{bankDetail.Code}\t{bankDetail.CreatedDate}\t{bankDetail.UpdatedDate}\n");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine($"There is no bank having Id:{id}");
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
                            var customersInABank = adoRepository.GetCustomerOfBank(inputBankId);
                            foreach (var item in customersInABank)
                            {
                                Console.WriteLine($"{item.BankId}\t{item.Name}\t{item.FirstName}\t{item.LastName}");
                            }
                            if (customersInABank.Count() == 0)
                            {
                                Console.WriteLine($"There is no Bank having Id as:{inputBankId}\n");
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
                            var customerAccount = adoRepository.GetCustomerAccount(inputCustomerId);
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
                            var customerWithNetWorth = adoRepository.CustomersWithNetWorth();
                            foreach (var item in customerWithNetWorth)
                            {
                                Console.WriteLine($"{item.Id}\t{item.FirstName}\t{item.LastName}");
                            }
                            Console.WriteLine();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        goto option;
                    case 7:
                        try
                        {                            
                            var addBankTable=dataValidator.GetBanksDataTable();
                            adoRepository.BulkInsertUsingAdo(addBankTable);
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
                        Console.WriteLine("Please enter a valid input\n");
                        goto option;
                }
            }
        }
        public void insertBank()
        {
            var bank = dataValidator.AddBankData();
            adoRepository.AddBank(bank);
        }
        public void InsertCustomer()
        {
            var customer = dataValidator.AddCustomerData();
            adoRepository.AddCustomer(customer);
        }
    }
}

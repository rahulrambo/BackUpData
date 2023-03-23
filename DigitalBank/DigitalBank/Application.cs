using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DigitalBank.Repository;
using DigitalBank.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank
{
    public class Application
    {
        private readonly DigitalBankContext context;

        Regex alphabetOnlyRegex = new Regex(@"[a-zA-Z]");
        static Repository.Repository repository = new DigitalBank.Repository.Repository();

        public Application()
        {
            context = new DigitalBankContext();
        }
        public static void Start(string[] args)
        {

            Application application = new Application();
            IEnumerable<Customer> customers = repository.GetCustomers();
            IEnumerable<Account> accounts = repository.GetAccounts();
        option:
            Console.WriteLine("Select your choice:");
            Console.WriteLine("Enter '1' for getting the Customer detail");
            Console.WriteLine("Enter '2' for getting the Customer detail by giving the Id");
            Console.WriteLine("Enter '3' for getting the Customer detail by giving the Name");
            Console.WriteLine("Enter '4' for adding a new Customer");
            Console.WriteLine("Enter '5' for updating a customer detail");
            Console.WriteLine("Enter '6' for deleting a customer");
            Console.WriteLine("Enter '7' for getting Account data");
            Console.WriteLine("Enter '8' for getting Account detail of a customer by giving the CustomerId");
            Console.WriteLine("Enter '9' for adding a new Account detail");
            Console.WriteLine("Enter '10' for updating the Account Detail");
            Console.WriteLine("Enter '11' for adding one more Bank");
            Console.WriteLine("Enter '12' for checking the Transaction history of the Customer");
            Console.WriteLine("Enter '13' for deleting a Bank along with its associated branches and accounts");
            Console.WriteLine("Enter '14' for getting the customers with their account in the bank with bank and branch name along with balance");
            Console.WriteLine("Enter '15' for getting the Bank Detail by Id using Lazy Loading ");
            Console.WriteLine("Enter '16' for getting the Bank Detail by Id using Eager Loading ");
            Console.WriteLine("Enter '17' for getting the Bank Detail by Id using Explicit Loading ");
            Console.WriteLine("Enter '18' for stopping the program");
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
                        Console.WriteLine("The Customer detail is as follow:");
                        customers.ToList().ForEach(x => Console.WriteLine($"{x.Id}\t{x.FirstName}\t{x.LastName}\t{x.Address1}\t{x.City}\t{x.District}\t{x.State}"));
                        Console.WriteLine();
                        goto option;
                    case 2:
                        Console.Write("Enter the CustomerId for getting the data:");
                    menu:
                        if (!int.TryParse(Console.ReadLine(), out int inputId))
                        {
                            Console.WriteLine("Please enter a valid CoustomerId");
                            goto menu;
                        }
                        var customer = repository.GetCustomerById(inputId);
                        if (customer != null)
                        {
                            Console.WriteLine($"Customer Detail having Id:{inputId} is as follow");
                            Console.WriteLine($"{customer.Id}\t{customer.FirstName}\t{customer.LastName}\t{customer.Address1}\t{customer.City}\t{customer.District}\t{customer.State}\n");
                        }
                        else
                        {
                            Console.WriteLine($"There is no customer having Id as:{inputId}\n");
                        }
                        goto option;
                    case 3:
                        Console.Write("Enter the Customer's FirstName for getting the data:");
                    fname:
                        string inputName = Console.ReadLine();
                        if (!application.alphabetOnlyRegex.IsMatch(inputName))
                        {
                            Console.WriteLine("Please enter a valid Name");
                            goto fname;
                        }
                        var customerName = repository.GetCustomerByName(inputName);
                        if (customerName != null)
                        {
                            Console.WriteLine($"Customer Detail having Name:{inputName} is as follow");
                            Console.WriteLine($"{customerName.Id}\t{customerName.FirstName}\t{customerName.LastName}\t{customerName.Address1}\t{customerName.City}\t{customerName.District}\t{customerName.State}\n");
                        }
                        else
                        {
                            Console.WriteLine($"There is no customer having Name as:{inputName}\n");
                        }
                        goto option;
                    case 4:
                        application.InsertCustomer();
                        Console.WriteLine("Customer added successfully\n");
                        goto option;
                    case 5:
                        Console.Write("Enter the CustomerId for updating the data:");
                    getCustomerId:
                        if (!int.TryParse(Console.ReadLine(), out int inputCustomerId))
                        {
                            Console.WriteLine("Please enter a valid CoustomerId");
                            goto getCustomerId;
                        }
                        var customerDetail = repository.GetCustomerById(inputCustomerId);
                        if (customerDetail != null)
                        {
                            application.UpdateCustomerDetail(customerDetail);
                            Console.WriteLine($"Customer detail is updated\n");
                        }
                        else
                        {
                            Console.WriteLine($"There is no customer having Id as:{inputCustomerId} Please enter a valid CustomerId!!!\n");
                            goto getCustomerId;
                        }
                        goto option;
                    case 6:
                        Console.Write("Enter the CustomerId for deleting the data:");
                    gotoCustomerDetail:
                        if (!int.TryParse(Console.ReadLine(), out int inputCustId))
                        {
                            Console.WriteLine("Please enter a valid CoustomerId");
                            goto gotoCustomerDetail;
                        }
                        var customerDtl = repository.GetCustomerById(inputCustId);
                        if (customerDtl != null)
                        {
                            repository.DeleteCustomer(customerDtl);
                            Console.WriteLine($"Customer is deleted successfully\n");
                        }
                        else
                        {
                            Console.WriteLine($"There is no customer having Id as:{inputCustId}");
                            goto gotoCustomerDetail;
                        }
                        goto option;
                    case 7:
                        Console.WriteLine("The account detail is as follow:");
                        accounts.ToList().ForEach(a => Console.WriteLine($"{a.Id}\t{a.CustomerId}\t{a.BankId}\t{a.BranchId}\t{a.AccountType}\t{a.IsActive}\t{a.Balance}"));
                        Console.WriteLine();
                        goto option;
                    case 8:
                        Console.Write("Enter the customerId for checking the account detail:");
                    accountMenu:
                        if (!int.TryParse(Console.ReadLine(), out int inputCustomerAccId))
                        {
                            Console.WriteLine("Please enter a valid CoustomerId");
                            goto accountMenu;
                        }
                        var account = repository.GetAccountById(inputCustomerAccId);
                        if (account != null)
                        {
                            Console.WriteLine($"Customer Detail having Id:{inputCustomerAccId} is as follow");
                            Console.WriteLine($"{account.Id}\t{account.CustomerId}\t{account.BankId}\t{account.BranchId}\t{account.AccountType}\t{account.IsActive}\t{account.Balance}\n");
                        }
                        else
                        {
                            Console.WriteLine($"There is no account detail of customer having Id as:{inputCustomerAccId}\n");
                        }
                        goto option;
                    case 9:
                        application.InsertAccount();
                        Console.WriteLine("Account added successfully\n");
                        goto option;
                    case 10:
                        Console.Write("Enter the CustomerId for updating the data:");
                    getAccount:
                        if (!int.TryParse(Console.ReadLine(), out int inputCustomerAccountId))
                        {
                            Console.WriteLine("Please enter a valid CoustomerId");
                            goto getAccount;
                        }
                        var accountDetails = repository.GetAccountById(inputCustomerAccountId);
                        if (accountDetails != null)
                        {
                            UpdateAccountDetail(accountDetails);
                            Console.WriteLine($"Account detail updated successfully");
                        }
                        else
                        {
                            Console.WriteLine($"There is no customer having Id as:{inputCustomerAccountId}\n");
                            goto getAccount;
                        }
                        goto option;
                    case 11:
                        application.InsertBank();
                        Console.WriteLine("Bank data added successfully!!!\n");
                        goto option;
                    case 12:
                        Console.Write("Enter the TransactionId for getting the data:");
                    getTransaction:
                        if (!int.TryParse(Console.ReadLine(), out int transactionId))
                        {
                            Console.WriteLine("Please enter a valid transactioId");
                            goto getTransaction;
                        }
                        var transaction = repository.GetTransactionById(transactionId);
                        if (transaction != null)
                        {
                            Console.WriteLine($"Transaction Detail having Id:{transactionId} is as follow");
                            Console.WriteLine($"{transaction.Id}\t{transaction.AccountId}\t{transaction.TransactionType}\t{transaction.Amount}\t{transaction.TransactionTime}\n");
                        }
                        else
                        {
                            Console.WriteLine($"There is no transaction history of a customer having AccountId as:{transactionId} Please enter a valid TransactionId!!\n");
                        }
                        goto option;
                    case 13:
                        Console.Write("Enter the BankId for deleting the Bank along with its associated branches and accounts:");
                    getBankId:
                        if (!int.TryParse(Console.ReadLine(), out int bankId))
                        {
                            Console.WriteLine("Please enter a valid BankId");
                            goto getBankId;
                        }
                        var bank = repository.GetBankById(bankId);
                        if (bank != null)
                        {
                            repository.DeleteBank(bank, bankId);
                            Console.Write($"The bank data has been deleted\n");
                        }
                        else
                        {
                            Console.WriteLine($"There is no bank having Id as:{bankId} Please enter a valid BankId!!!\n");
                            goto getBankId;
                        }
                        goto option;
                    case 14:
                        application.PrintCustomer();
                        goto option;
                    case 15:
                        Console.Write("Enter the BankId for checking the Bank detail:");
                    lazyMenu:
                        if (!int.TryParse(Console.ReadLine(), out int inputBankId))
                        {
                            Console.WriteLine("Please enter a valid BankId");
                            goto lazyMenu;
                        }
                        var branchDetailUsingLazyLoading = repository.GetBankById(inputBankId);
                        if (branchDetailUsingLazyLoading != null)
                        {
                            Console.WriteLine($"Branch Detail having BankId:{inputBankId} is as follow:");
                            application.GetBankByIdUsingLazyLoading(inputBankId);
                        }
                        else
                        {
                            Console.WriteLine($"There is no bank having Id as:{inputBankId} Please enter a valid BankId!!!");
                            goto lazyMenu;
                        }
                        goto option;
                    case 16:
                        Console.Write("Enter the BankId for checking the Bank detail:");
                    eagerMenu:
                        if (!int.TryParse(Console.ReadLine(), out int bankInputId))
                        {
                            Console.WriteLine("Please enter a valid BankId");
                            goto eagerMenu;
                        }
                        var branchDetailUsingEagerLoading = repository.GetBankById(bankInputId);
                        if (branchDetailUsingEagerLoading != null)
                        {
                            Console.WriteLine($"Branch Detail having BankId:{bankInputId} is as follow:");
                            application.GetBankByIdUsingEagerLoading(bankInputId);
                        }
                        else
                        {
                            Console.WriteLine($"There is no bank having Id as:{bankInputId} Please enter a valid BankId!!!");
                            goto eagerMenu;
                        }
                        goto option;
                    case 17:
                        Console.Write("Enter the BankId for checking the Bank detail:");
                    explicitMenu:
                        if (!int.TryParse(Console.ReadLine(), out int Id))
                        {
                            Console.WriteLine("Please enter a valid BankId");
                            goto explicitMenu;
                        }
                        var branchDetailUsingExplicitLoading = repository.GetBankById(Id);
                        if (branchDetailUsingExplicitLoading != null)
                        {
                            Console.WriteLine($"Branch Detail having BankId:{Id} is as follow:");
                            application.GetBankByIdUsingExplicitLoading(Id);
                        }
                        else
                        {
                            Console.WriteLine($"There is no bank having Id as:{Id} Please enter a valid BankId!!!");
                            goto explicitMenu;
                        }
                        goto option;
                    case 18:
                        input = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input\n");
                        goto option;
                }
            }
        }
        public void InsertCustomer()
        {
            Console.Write("Enter the first name:");
        getFirstName:
            string firstName = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(firstName))
            {
                Console.WriteLine("Please enter a valid Name");
                goto getFirstName;
            }
            Console.Write("Enter the Last name:");
        getLastName:
            string lastName = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(lastName))
            {
                Console.WriteLine("Please enter a valid Name");
                goto getLastName;
            }
            Console.Write("Enter the address:");
        getAddress:
            string address = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(address))
            {
                Console.WriteLine("Please enter a valid address");
                goto getAddress;
            }
            Console.Write("Enter the City:");
        getCity:
            string city = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(city))
            {
                Console.WriteLine("Please enter a valid city");
                goto getCity;
            }
            Console.Write("Enter the District:");
        getDistrict:
            string district = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(district))
            {
                Console.WriteLine("Please enter a valid district");
                goto getDistrict;
            }
            Console.Write("Enter the State:");
        getState:
            string state = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(state))
            {
                Console.WriteLine("Please enter a valid state");
                goto getState;
            }
            Console.Write("Enter the ZipCode:");
            string zipCode = Console.ReadLine();

            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address1 = address,
                City = city,
                District = district,
                State = state,
                ZipCode = zipCode,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            int bankId;
            int branchId;
        getbankId:
            do
            {
                Console.Write("Enter the bank id:");
            } while (!int.TryParse(Console.ReadLine(), out bankId));
            var bank = repository.GetBankById(bankId);
            if (bank == null)
            {
                Console.WriteLine($"There is no Bank having Id as:{bankId}");
                Console.WriteLine("Please enter a valid BankId");
                goto getbankId;
            }
        getBranchId:
            do
            {
                Console.Write("Enter your branchId:");
            } while (!int.TryParse(Console.ReadLine(), out branchId));
            var bankBranch = repository.GetBankBranchById(branchId);
            if (bankBranch == null)
            {
                Console.WriteLine($"There is no Branch having BranchId as:{branchId}");
                Console.WriteLine("Please enter a valid BranchId");
                goto getBranchId;
            }
            Console.Write("Enter Balance for opening Account:");
        getAmount:
            if (!decimal.TryParse(Console.ReadLine(), out decimal amt))
            {
                Console.WriteLine("Please Enter a valid Amount");
                goto getAmount;
            }
            Account account = new Account()
            {
                CustomerId = customer.Id,
                BankId = 1,
                BranchId = 1,
                AccountType = "Saving",
                IsActive = true,
                Balance = amt,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Bank = bank,
                Branch = bankBranch,
                Customer = customer,
            };
            Transaction transactions = new Transaction()
            {
                AccountId = account.Id,
                TransactionType = "Deposit",
                Amount = account.Balance,
                TransactionTime = DateTime.Now,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Account = account,
            };
            customer.Accounts.Add(account);            
            repository.AddCustomer(customer);
        }
        public void UpdateCustomerDetail(Customer customer)
        {
        option:
            Console.WriteLine("Select your choice:");
            Console.WriteLine("Enter '1' for updating the FirstName of Customer");
            Console.WriteLine("Enter '2' for updating the LastName of Customer");
            Console.WriteLine("Enter '3' for updating the Address of Customer");
            if (!int.TryParse(Console.ReadLine(), out int inputValue))
            {
                Console.WriteLine("Please enter a valid input");
                goto option;
            }
            switch (inputValue)
            {
                case 1:
                    Console.Write("Enter the FirstName to be updated:");
                fname:
                    string updatedFirstName = Console.ReadLine();
                    if (!alphabetOnlyRegex.IsMatch(updatedFirstName))
                    {
                        Console.WriteLine("Please enter a valid Name");
                        goto fname;
                    }
                    customer.FirstName = updatedFirstName;
                    Console.WriteLine("FirstName has been updated");
                    break;
                case 2:
                    Console.Write("Enter the LastName to be updated:");
                lname:
                    string updatedLastName = Console.ReadLine();
                    if (!alphabetOnlyRegex.IsMatch(updatedLastName))
                    {
                        Console.WriteLine("Please enter a valid Name");
                        goto lname;
                    }
                    customer.LastName = updatedLastName;
                    Console.WriteLine("LastName has been updated");
                    break;
                case 3:
                    Console.Write("Enter the Address to be updated:");
                    string updatedAddress = Console.ReadLine();
                    customer.Address1 = updatedAddress;
                    Console.Write("Enter the City to be updated:");
                city:
                    string updatedCity = Console.ReadLine();
                    if (!alphabetOnlyRegex.IsMatch(updatedCity))
                    {
                        Console.WriteLine("Please enter a valid Name");
                        goto city;
                    }
                    customer.City = updatedCity;
                    Console.Write("Enter the District to be updated:");
                dist:
                    string updatedDistrict = Console.ReadLine();
                    if (!alphabetOnlyRegex.IsMatch(updatedDistrict))
                    {
                        Console.WriteLine("Please enter a valid Name");
                        goto dist;
                    }
                    customer.District = updatedDistrict;
                    Console.Write("Enter the State to be updated:");
                state:
                    string updatedState = Console.ReadLine();
                    if (!alphabetOnlyRegex.IsMatch(updatedState))
                    {
                        Console.WriteLine("Please enter a valid Name");
                        goto state;
                    }
                    customer.State = updatedState;
                    Console.Write("Enter the ZipCode to be updated:");
                    string updatedZipCode = Console.ReadLine();
                    customer.ZipCode = updatedZipCode;
                    Console.WriteLine("Address has been updated");
                    break;
            }
            repository.UpdateCustomer(customer);
        }
        public void InsertAccount()
        {
            Console.Write("Enter customerId for adding account data:");
        getCustomerId:
            if (!int.TryParse(Console.ReadLine(), out int custId))
            {
                Console.WriteLine("Please enter a valid input");
                goto getCustomerId;
            }
            var customer = context.Customers.FirstOrDefault(c => c.Id == custId);
            if (customer == null)
            {
                Console.WriteLine($"There is no customer having Id as:{custId}");
                Console.WriteLine("Please enter a valid Customer Id");
                goto getCustomerId;
            }
            Console.Write("Enter BankId:");
        getBankId:
            if (!int.TryParse(Console.ReadLine(), out int bankId))
            {
                Console.WriteLine("Please enter a valid input");
                goto getBankId;
            }
            var bank = context.Banks.FirstOrDefault(c => c.Id == bankId);
            if (bank == null)
            {
                Console.WriteLine($"There is no such Bank having Id as:{bankId}");
                Console.WriteLine("Please enter a valid BankId");
                goto getBankId;
            }
            Console.Write("Enter BranchId:");
        getBranchId:
            if (!int.TryParse(Console.ReadLine(), out int bankBranchId))
            {
                Console.WriteLine("Please enter a valid input");
                goto getBranchId;
            }
            var bankBranch = context.BankBranches.FirstOrDefault(c => c.Id == bankBranchId);
            if (bankBranch == null)
            {
                Console.WriteLine($"There is no such type of Branch having Id as:{bankBranchId}");
                Console.WriteLine("Please enter a valid BranchId");
                goto getBranchId;
            }
            Console.Write("Enter Account Type:");
        accType:
            string accountType = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(accountType))
            {
                Console.WriteLine("Please enter a valid AccountType");
                goto accType;
            }
            Console.WriteLine("Enter the account is active or not");
            bool activeOrNot;
            while (!bool.TryParse(Console.ReadLine(), out activeOrNot))
            {
                Console.WriteLine("Please enter a valid input");
            }
            Console.Write("Enter the balance:");
        balance:
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                Console.WriteLine("Please enter a valid input");
                goto balance;
            }
            Account account = new Account()
            {
                CustomerId = custId,
                BankId = bankId,
                BranchId = bankBranchId,
                AccountType = accountType,
                IsActive = activeOrNot,
                Balance = amount,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            repository.AddAccount(account);
        }
        public static void UpdateAccountDetail(Account account)
        {
        option:
            Console.WriteLine("\nSelect your choice:");
            Console.WriteLine("Enter '1' for updating the Account status i.e. Account is active or not");
            Console.WriteLine("Enter '2' for updating the Balance of an account");
            if (!int.TryParse(Console.ReadLine(), out int inputValue))
            {
                Console.WriteLine("Please enter a valid input");
                goto option;
            }
            switch (inputValue)
            {
                case 1:
                    Console.Write("Enter 'TRUE' for continuing the account or else enter 'FALSE':");
                    bool activeOrNot;
                    while (!bool.TryParse(Console.ReadLine(), out activeOrNot))
                    {
                        Console.WriteLine("Please enter a valid input");
                    }
                    account.IsActive = activeOrNot;
                    Console.WriteLine("Account status has been updated");
                    break;
                case 2:
                    Console.Write("Enter the Amount you want to add:");
                balance:
                    if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        Console.WriteLine("Please enter a valid input");
                        goto balance;
                    }
                    account.Balance = amount;
                    Console.WriteLine("Account Balance has been updated");
                    break;
            }
            repository.UpdateAccount(account);
        }
        public void InsertBank()
        {
            Console.Write("Enter the Bank Name which you want to add:");
        getBankName:
            string bankName = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(bankName))
            {
                Console.WriteLine("Please enter a valid Name");
                goto getBankName;
            }
            Console.Write("Enter the Bank Code for the bank:");
        getBankCode:
            string bankCode = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(bankCode))
            {
                Console.WriteLine("Please enter a valid BankCode");
                goto getBankCode;
            }
            Bank bank = new Bank()
            {
                Name = bankName,
                Code = bankCode,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            Console.Write("Enter the Branch Code:");
        getCode:
            string branchcode = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(branchcode))
            {
                Console.WriteLine("Please enter a valid BranchCode");
                goto getCode;
            }
            Console.Write("Enter the Branch address:");
        getAddress:
            string address = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(address))
            {
                Console.WriteLine("Please enter a valid address");
                goto getAddress;
            }
            Console.Write("Enter the Branch City:");
        getCity:
            string city = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(city))
            {
                Console.WriteLine("Please enter a valid City Name");
                goto getCity;
            }
            Console.Write("Enter the Branch District:");
        getdistrict:
            string district = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(district))
            {
                Console.WriteLine("Please enter a valid District Name");
                goto getdistrict;
            }
            Console.Write("Enter the Branch State:");
        getState:
            string state = Console.ReadLine();
            if (!alphabetOnlyRegex.IsMatch(state))
            {
                Console.WriteLine("Please enter a valid State Name");
                goto getState;
            }
            Console.Write("Enter the ZipCode:");
            string zipCode = Console.ReadLine();
            var bankBranch = new BankBranch()
            {
                Code = branchcode,
                Address1 = address,
                City = city,
                District = district,
                State = state,
                ZipCode = zipCode,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            bank.BankBranches.Add(bankBranch);
            repository.AddBank(bank);
        }
        public void PrintCustomer()
        {
            var printCustomer = from b in context.Banks
                                join br in context.BankBranches on b.Id equals br.BankId
                                join a in context.Accounts on br.Id equals a.BranchId
                                join c in context.Customers on a.CustomerId equals c.Id
                                select new
                                {
                                    CustomerName = c.FirstName,
                                    BankName = b.Name,
                                    BranchName = br.Code,
                                    Balance = a.Balance
                                };
            foreach (var item in printCustomer.Distinct())
            {
                Console.WriteLine($"{item.CustomerName}\t{item.BankName}\t{item.BranchName}\t{item.Balance}");
            }
            Console.WriteLine();
        }
        public Bank GetBankByIdUsingLazyLoading(int bankId)
        {
            var bank = context.Banks.FirstOrDefault(b => b.Id == bankId);
            foreach (var branch in bank.BankBranches)
            {
                Console.WriteLine($"{branch.Id}\t{branch.Code}\t{branch.BankId}\t{branch.City}");
            }
            Console.WriteLine();
            return bank;
        }
        public Bank GetBankByIdUsingEagerLoading(int bankId)
        {
            var bank = context.Banks.Include(br => br.BankBranches).FirstOrDefault(b => b.Id == bankId);
            foreach (var item in bank.BankBranches)
            {
                Console.WriteLine($"{item.Code}\t{item.Address1}\t{item.City}");
            }
            Console.WriteLine();
            return bank;
        }
        public Bank GetBankByIdUsingExplicitLoading(int bankId)
        {
            Bank bank = context.Banks.FirstOrDefault(b => b.Id == bankId);
            context.Entry(bank).Collection(b => b.BankBranches).Load();
            foreach (var item in bank.BankBranches)
            {
                Console.WriteLine($"{item.Code}\t{item.Address1}\t{item.City}");
            }
            Console.WriteLine();
            return bank;
        }
    }
}

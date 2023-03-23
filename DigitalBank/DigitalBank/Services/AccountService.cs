using DigitalBank.Core.Entities;
using DigitalBank.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitalBank.Services
{
    public class AccountService
    {
        Account account;

        Regex regexFirstName = new Regex(@"^[a-zA-Z ]+$");
        Regex regexLastName = new Regex(@"^[a-zA-Z]+$");        
        public AccountService()
        {
            Console.WriteLine("For opening account ");
        acceptFirstName:
            Console.Write("\nPlease Enter your First Name:");
            string firstName = Console.ReadLine();            
            if(!regexFirstName.IsMatch(firstName))
            {
                Console.WriteLine("Please enter a valid name");
                goto acceptFirstName;
            }
        acceptLastName:
            Console.Write("Please Enter your Last Name:");
            string lastName = Console.ReadLine();
            if (!regexLastName.IsMatch(lastName))
            {
                Console.WriteLine("Please enter a valid name");
                goto acceptLastName;
            }
        openingAccount:
            Console.Write("Enter Your Opening Balance Amount:");
            decimal openingAmount;            
            if(!decimal.TryParse(Console.ReadLine(), out openingAmount))
            {
                Console.WriteLine("Please enter a valid Amount");
                goto openingAccount;
            }
            try
            {
                account = new Account(firstName, lastName, openingAmount);
                Console.WriteLine($"\nCongratulations on opening an account with us with an opening balance of {openingAmount}!");
            }
            catch (Exception)
            {

                Console.WriteLine("\nBALANCE SHOULD BE MORE THAN OR EQUAL TO 500!");
                goto openingAccount;
            }
        }
        public void DepositAmount()
        {
        depositingAmount:
            Console.Write("Enter your amount as you want to Deposit:");
            decimal depositAmount;
            if (!decimal.TryParse(Console.ReadLine(), out depositAmount))
            {
                Console.WriteLine("Please enter a valid amount");
                goto depositingAmount;
            }
        acceptDepositNote:
            Console.Write("Please Write the purpose of Deposit:");
            string depositNote = Console.ReadLine(); 
            if(!regexFirstName.IsMatch(depositNote))
            {
                Console.WriteLine("Please enter a valid purpose");
                goto acceptDepositNote;
            }            
            try
            {
                account.Deposit(depositAmount, depositNote);
                Console.WriteLine($"Updated Balance after Deposit:{account.Balance}");
            }
            catch (Exception)
            {
                Console.WriteLine("\nDEPOSITE AMOUNT CAN'T BE 0 OR LESS THAN 0 PLEASE ENTER VALID AMOUNT!");
                goto depositingAmount;
            }
        }
        public void WithdrawAmount()
        {
        withdrawalAmount:
            Console.Write("Enter your amount as you want to withdraw:");
            decimal withdrawAmount;
            if(!decimal.TryParse(Console.ReadLine(), out withdrawAmount))
            {
                Console.WriteLine("Please enter a valid amount");
                goto withdrawalAmount;
            }
        acceptWithdrawNote:
            Console.Write("Please Write the purpose of Withdrawal:");
            string withdrawNote = Console.ReadLine();           
            if(!regexFirstName.IsMatch(withdrawNote))
            {
                Console.WriteLine("Please enter a valid purpose");
                goto acceptWithdrawNote;
            }                        
            try
            {
                account.Withdraw(withdrawAmount, withdrawNote);
                Console.WriteLine($"Remaining Balance after withdrawal:{account.Balance}");
            }
            catch (Exception)
            {
                Console.WriteLine("\nWITHDRAWAL AMOUNT CAN'T BE ZERO,NEGATIVE OE MORE THAN AVAILABLE BALANCE!\n");
                goto withdrawalAmount;
            }
        }
        public void BalanceCheck()
        {
            Console.WriteLine("Current Balance is:" + account.Balance);
        }

        public void TransactionSlip()
        {
            Console.WriteLine(account.Transactions.GetTransactionHistory());
        }
    }
}

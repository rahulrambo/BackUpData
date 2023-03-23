using DigitalBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Extensions
{
    public static class TransactionExtensions
    {
        public static string GetTransactionHistory(this List<Transaction> allTransactions)
        {
            StringBuilder result = new StringBuilder();            
            result.AppendLine("Date\t\t\tAmount\tCurrency\tBalance\tType\t\t\tNote");
            foreach (var transactionData in allTransactions)
            {
                result.AppendLine($"{transactionData.Date}\t{transactionData.Amount}\t{transactionData.Currency}\t\t{transactionData.TotalBalance}\t{transactionData.TransactionType}\t\t{transactionData.Note}");
            }
            return result.ToString();
        }
    }
}

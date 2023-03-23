using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitalBank.Core
{
    public class Constants
    {
        public const string AlphabetOnlyRegex = @"[a-zA-Z]";
        public const string ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DigitalBank; Integrated Security = True";
        public struct Queries
        {
            public const string InsertBank = "INSERT INTO Bank ([Name], [Code], [CreatedDate], [UpdatedDate]) VALUES (@Name,@Code,@CreatedDate,@UpdatedDate)";
            public const string InsertCustomer = "INSERT INTO Customer(FirstName,LastName,Address1,City,District,[State],ZipCode,CreatedDate,UpdatedDate) VALUES(@FirstName,@LastName,@Address,@City,@District,@State,@ZipCode,@CreatedDate,@UpdatedDate)";
            public const string GetBank = "select * from Bank where Id=@id";
            public const string CustomersOfABank = "select a.BankId, b.Name as BankName, c.FirstName,c.LastName from Bank as b inner join Account as a on a.BankId = b.Id inner join Customer as c on a.CustomerId = c.Id where b.id = @Id";
            public const string CustomerAccount = "select a.Id as AccountId,a.CustomerId,c.FirstName,a.BankId,a.BranchId,a.AccountType,a.Balance from Account as a inner join Customer as c on a.CustomerId = c.Id where c.Id = @Id";
            public const string CustomersWithNetWorth = "select top 5 c.Id,c.FirstName,c.LastName,SUM(a.Balance)as TotalBalance from Account a inner join Customer c on a.CustomerId = c.Id group by a.Id,c.Id,c.FirstName,c.LastName,c.State order by TotalBalance desc";
        }
    }
}

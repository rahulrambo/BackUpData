namespace DigitalBank.Business.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
    }
}
